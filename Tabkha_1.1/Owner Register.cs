using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;
using System.Xml.Linq;
using Tabkha_1._1;
using Tabkha_1._1.Class;
using System.Text.RegularExpressions;

namespace Tabkha_1._1
{
    public partial class Owner_Register : Form
    {

        login login = new login();

        public Owner_Register()
        {
            InitializeComponent();
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
            else if (txt_fname.Text=="" 
                ||txt_password.Text == "" 
                ||txt_email.Text==""
                || txt_confirmPassword.Text==""
                || txtbox_phoneNumber.Text==""
                ||txtbox_bio.Text==""
                || txtbox_businesssName.Text=="")
            {
                MessageBox.Show("Please fill out all required fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string First_Name = txt_fname.Text.Trim();
                string Last_Name = txtbox_lname.Text.Trim();   
                string Password = txt_password.Text.Trim();
                string Confirm_Password = txt_confirmPassword.Text.Trim();
                string Email = txt_email.Text.Trim();
                string Phone_Number = txtbox_phoneNumber.Text.Trim();
                string restaurant_name= txtbox_businesssName.Text.Trim();
                string bio = txtbox_bio.Text.Trim();
                string fullname = First_Name + " " + Last_Name;

                using (SqlConnection connect = new SqlConnection(Connection.connectionString))
                {
                    try
                    {
                        connect.Open();
                        string query = "INSERT INTO Chefs (Fname,Lname,Password,Email,Phone,Rname,Bio)VALUES (@fname,@lname,@password,@email,@phonenumber,@resname,@bio);";
                        using (SqlCommand cmd = new SqlCommand(query, connect))
                        {
                            cmd.Parameters.AddWithValue("@fname", First_Name);
                            cmd.Parameters.AddWithValue("@lname", Last_Name);
                            cmd.Parameters.AddWithValue("@password", Password);
                            cmd.Parameters.AddWithValue("@email", Email);
                            cmd.Parameters.AddWithValue("@phonenumber", Phone_Number);
                            cmd.Parameters.AddWithValue("@resname", restaurant_name);
                            cmd.Parameters.AddWithValue("@bio", bio);
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

        private void img_minimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void img_close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void register_card_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_signIn_Click(object sender, EventArgs e)
        {
            login.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Owner_Register_Load(object sender, EventArgs e)
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
        private void SendWelcomeEmail(string name, string user_email)
        {
            string subject = "Welcome to Our System!";
            string body = $"Dear {name},\n\n Welcome to Tabkha System !\nWelcome to the Tabkha System! We are thrilled to have you onboard and look forward to supporting your culinary journey with our platform.\n\nTabkha is designed to simplify your operations, enhance your team’s efficiency, and deliver an exceptional experience for your customers. Should you have any questions or need assistance, our dedicated support team is always here to help.\n\n" +
                $"Let’s cook up success together!\n\nWarm regards,\r\nTabkha Team'''...!";
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

        private void lbl_login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide() ;
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
