using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        string connectionString = @"Data Source=LAPTOP-EBHNP4IJ\;Initial Catalog=tabkha_system;Integrated Security=True";
        private void img_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void img_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_email.Text = "";
            txt_password.Text = "";
            txt_confirmPassword.Text = "";
            txt_phone.Text = "";
            txt_lname.Text = "";
            txtbox_address.Text = "";
            txtbox_city.Text = "";
            txtbox_fname.Text = "";


        }

        private void btn_signUp_Click(object sender, EventArgs e)
        {
            if (txt_confirmPassword.Text != txt_password.Text)
            {
                MessageBox.Show("Review password");
            }
            else if (txt_email.Text == ""
           || txt_password.Text == ""
           || txt_confirmPassword.Text == ""
           || txt_phone.Text == ""
           || txt_lname.Text == ""
           || txtbox_address.Text == ""
           || txtbox_city.Text == ""
           || txtbox_fname.Text == "")
            { MessageBox.Show("Required Fields Empty"); }
            else
            {
                string First_Name = txtbox_fname.Text;
                string Last_Name = txt_lname.Text;
                string Password = txt_password.Text;
                string Confirm_Password = txt_confirmPassword.Text;
                string Email = txt_email.Text;
                string Phone_Number = txt_phone.Text;
                string City = txtbox_city.Text;
                string Address = txtbox_address.Text;
                string fullname = First_Name + " " + Last_Name;

                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    try
                    {
                        connect.Open();
                        string query = "INSERT INTO customers (customer_firstname,customer_lastname,customer_password,customer_confirmpassword,customer_phonen,customer_email,customer_city,customer_address)VALUES (@firstname,@lastname,@password,@confirmpassword,@phonenumber,@email,@city,@address);";
                        using (SqlCommand cmd = new SqlCommand(query, connect))
                        {
                            cmd.Parameters.AddWithValue("@firstname", First_Name);
                            cmd.Parameters.AddWithValue("@lastname", Last_Name);
                            cmd.Parameters.AddWithValue("@password", Password);
                            cmd.Parameters.AddWithValue("@confirmpassword", Confirm_Password);
                            cmd.Parameters.AddWithValue("@phonenumber", Phone_Number);
                            cmd.Parameters.AddWithValue("@email", Email);
                            cmd.Parameters.AddWithValue("@city", City);
                            cmd.Parameters.AddWithValue("@address", Address);
                            int rowaffected = cmd.ExecuteNonQuery();
                            if (rowaffected > 0)
                            {
                                SendWelcomeEmail(fullname, Email);
                                user_home user_Home = new user_home();
                                user_Home.Show();
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
    }
}
