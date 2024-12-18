using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tabkha_1._1.Class;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Tabkha_1._1
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }
        private void img_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void img_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsValidEmail(string email)
        {
            // Regular expression for email validation
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private void btn_signUp_Click(object sender, EventArgs e)
        {
            
            if (txt_confirmPassword.Text != txt_password.Text)
            {
                MessageBox.Show("Passwords do not match. Please review your password fields.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidEmail(txt_email.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txt_email.Text == ""
           || txt_password.Text == ""
           || txt_confirmPassword.Text == ""
           || txt_phone.Text == ""
           || txt_lname.Text == ""
           || txtbox_address.Text == ""
           || txtbox_city.Text == ""
           || txtbox_fname.Text == "")
            {
                MessageBox.Show("Please fill out all required fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {

                string First_Name = txtbox_fname.Text.Trim();
                string Last_Name = txt_lname.Text.Trim();
                string Password = txt_password.Text;
                string Confirm_Password = txt_confirmPassword.Text;
                string Email = txt_email.Text.Trim();
                string Phone_Number = txt_phone.Text.Trim();
                string City = txtbox_city.Text.Trim();
                string Address = txtbox_address.Text.Trim();
                string fullname = First_Name + " " + Last_Name;

                using (SqlConnection connect = Connection.Instance.GetConnection())
                {
                    try
                    {
                        connect.Open();

                        string query = "INSERT INTO Users (Fname,Lname,Password,Email,Phone,City,Address) VALUES (@firstname,@lastname ,@password,@email,@phonenumber,@city,@address);";

                        using (SqlCommand cmd = new SqlCommand(query, connect))
                        {
                            cmd.Parameters.AddWithValue("@firstname", First_Name);
                            cmd.Parameters.AddWithValue("@lastname", Last_Name);
                            cmd.Parameters.AddWithValue("@password", Password);
                            cmd.Parameters.AddWithValue("@email", Email);
                            cmd.Parameters.AddWithValue("@phonenumber", Phone_Number);
                            cmd.Parameters.AddWithValue("@city", City);
                            cmd.Parameters.AddWithValue("@address", Address);
                            int rowaffected = cmd.ExecuteNonQuery();
                            if (rowaffected > 0)
                            {

                                SendWelcomeEmail(fullname, Email);
                                login login = new login();
                                login.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Register failed , try again");
                            }
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("errorrrrrr: " + ex.Message); }
                }

            }


        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void SendWelcomeEmail(string name, string user_email)
        {
            string subject = "Welcome to Our System!";
            string body = $"Dear {name},\n\n Welcome to Tabkha System !\n Whether you're here to create culinary masterpieces or enjoy the finest dishes, you're in the right place. Together, we celebrate the joy of cooking, sharing, and savoring amazing food. Let’s make every meal a memorable one...!";
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("asma37amd@gmail.com");
                mail.To.Add(user_email);
                mail.Subject = subject;
                mail.Body = body;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com"))
                {
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("asma37amd@gmail.com", "hugveqskeeqrabuk");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }

        private void btn_eye_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility();
        }

        private bool isPasswordVisible = false;

        private void button1_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility();
        }
        private void TogglePasswordVisibility()
        {
            if (isPasswordVisible)
            {
                // Hide the password
                txt_password.PasswordChar = '\u2022';
                txt_confirmPassword.PasswordChar = '\u2022';
                btn_eye.Image = Properties.Resources.eye__1_;
                button1.Image = Properties.Resources.eye__1_;// Replace with 'eye closed' icon
                isPasswordVisible = false;
            }
            else
            {
                // Show the password
                txt_password.PasswordChar = '\0';
                txt_confirmPassword.PasswordChar = '\0';
                btn_eye.Image = Properties.Resources.eye;
                button1.Image = Properties.Resources.eye;// Replace with 'eye open' icon
                isPasswordVisible = true;
            }
        }
        private string placeholderText1 = "Confirm password"; // Set your placeholder text
        private Color placeholderColor = Color.Gray;  // Light gray for placeholder
        private Color textColor = Color.Black;

        private void txt_confirmPassword_Enter(object sender, EventArgs e)
        {
            if (txt_confirmPassword.Text == placeholderText1)
            {
                txt_confirmPassword.Text = "";
                txt_confirmPassword.ForeColor = textColor;

                // Ensure PasswordChar works only when the placeholder is gone
                txt_confirmPassword.PasswordChar = isPasswordVisible ? '\0' : '\u2022';
            }
        }

        private void txt_confirmPassword_Leave(object sender, EventArgs e)
        {
            // Restore placeholder if the textbox is empty
            if (string.IsNullOrWhiteSpace(txt_confirmPassword.Text))
            {
                txt_confirmPassword.Text = placeholderText1;
                txt_confirmPassword.ForeColor = placeholderColor;

                // Disable masking to show placeholder clearly
                txt_confirmPassword.PasswordChar = '\0';
            }
        }

        private string placeholderText = "Enter your password";
        private void register_Load(object sender, EventArgs e)
        {
            // Initialize placeholder on form load
            txt_password.Text = placeholderText;
            txt_confirmPassword.Text = placeholderText1;
            txt_confirmPassword.ForeColor = placeholderColor;
            txt_password.ForeColor = placeholderColor;
            txt_password.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
            txt_confirmPassword.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);

            // Disable masking to show placeholder text
            txt_password.PasswordChar = '\0';
            txt_confirmPassword.PasswordChar = '\0';
        }

        private void txt_password_Enter(object sender, EventArgs e)
        {
            if (txt_password.Text == placeholderText)
            {
                txt_password.Text = "";
                txt_password.ForeColor = textColor;

                // Ensure PasswordChar works only when the placeholder is gone
                txt_password.PasswordChar = isPasswordVisible ? '\0' : '\u2022';
            }
        }

        private void txt_password_Leave(object sender, EventArgs e)
        {
            // Restore placeholder if the textbox is empty
            if (string.IsNullOrWhiteSpace(txt_password.Text))
            {
                txt_password.Text = placeholderText;
                txt_password.ForeColor = placeholderColor;

                // Disable masking to show placeholder clearly
                txt_password.PasswordChar = '\0';
            }
        }
    } 
}
