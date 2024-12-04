using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabkha_1._1
{
    public partial class ResetPassword : Form
    {
        public static class globalvariables
        {
            public static string global_email;
        }
        public ResetPassword()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=LAPTOP-EBHNP4IJ\;Initial Catalog=tabkha_system;Integrated Security=True";

        private void img_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void img_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            forget forgetPassword = new forget();
            forgetPassword.Show();
            this.Hide();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            string pass = customTextBox1.Text;
            string confirm_pass = customTextBox2.Text;

            if (pass != confirm_pass) { MessageBox.Show("Password and confirm password do not match , please try again"); }
            else
            {
                string email = globalvariables.global_email;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();


                        string query = "update  customers set customer_password=@password, customer_confirmpassword=@confirmpassword where customer_email=@email";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {


                            cmd.Parameters.AddWithValue("@password", pass);
                            cmd.Parameters.AddWithValue("@confirmpassword", confirm_pass);
                            cmd.Parameters.AddWithValue("@email", email);

                            int rowaffected = Convert.ToInt32(cmd.ExecuteScalar());
                            if (rowaffected > 0)
                            {
                                user_home user_Home = new user_home();
                                user_Home.Show();
                                this.Hide();
                            }
                            else
                            {
                                login login = new login();
                                login.Show();
                                this.Hide();

                            }


                        }



                    }
                    catch (Exception ex) { MessageBox.Show("errorrrrrr: " + ex.Message); }
                }
            }


        }


    }
}

