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

namespace Tabkha_1._1
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void img_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        string connectionString = @"Data Source=LAPTOP-EBHNP4IJ\;Initial Catalog=tabkha_system;Integrated Security=True";
        private string query;

        private void img_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_signIn_Click(object sender, EventArgs e)
        {

            string user_name = txt_username.Text;
            string password = txt_password.Text;
            if (chk_rememberMe.Checked == true)
            {
                if (user_name == "")
                {
                    MessageBox.Show("please enter you email");
                }
                else
                {
                    Sendcode(user_name);
                    MessageBox.Show("we send password to you if your email is correct");
                }
            }
            

           if (txt_password.Text == ""
                || txt_username.Text == "")
            { MessageBox.Show("Required Fields Empty"); }

            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        if (user_name.Contains('@') == true)
                        {
                            query = "select count(1) from customers where customer_email=@email and customer_password=@password";

                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        // تخزين بيانات المستخدم في الجلسة
                                        Session.Id = Convert.ToInt32(reader["customer_id"]);
                                        Session.Email = reader["customer_email"].ToString();
                                        Session.Name = user_name;
                                        Session.Pic = reader["DishPic"].ToString();
                                    }

                                    int rowaffected = Convert.ToInt32(cmd.ExecuteScalar());
                                    if (rowaffected > 0)
                                    {
                                        user_home user_Home = new user_home();
                                        user_Home.Show();
                                        this.Hide();
                                    }
                                }
                            }
                        }
                        else
                        {
                            query = "select count(1) from customers where customer_phonen=@phone and customer_password=@password";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@phone", user_name);
                                cmd.Parameters.AddWithValue("@password", password);
                                int rowaffected = Convert.ToInt32(cmd.ExecuteScalar());
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        // تخزين بيانات المستخدم في الجلسة
                                        Session.Id = Convert.ToInt32(reader["customer_id"]);
                                        Session.Name = user_name;
                                    }
                                    if (rowaffected > 0)
                                    {
                                        user_home user_Home = new user_home();
                                        user_Home.Show();
                                        this.Hide();
                                    }

                                    }
                                }




                    catch (Exception ex) { MessageBox.Show("errorrrrrr: " + ex.Message); }
                }


            }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            option_for_register option = new option_for_register();
            option.Show();
        }

        private void L_lbl_forgetPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            forget forget = new forget();
            forget.Show();
            this.Hide();
        }
        private void Sendcode(string user_email)
        {
            string password = "";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                
                
                    conn.Open();
                   
                        query = "select customer_password from customers where customer_email=@email ";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {

                             cmd.Parameters.AddWithValue("@email", user_email);
                             using (SqlDataReader reader = cmd.ExecuteReader())
                             {
                                   if(reader.Read())
                                   {
                                        password = reader["customer_password"].ToString();
                                        

                                   }

                             }

                   
                        }   
            }

            string subject = "Welcome to Our System!";
            string body = $"  your password is   {password}    ...!";
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
