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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Tabkha_1._1
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=LAPTOP-EBHNP4IJ\;Initial Catalog=tabkha_system;Integrated Security=True";

        private void img_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void img_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_signIn_Click(object sender, EventArgs e)
        {
            string User_Name=txt_username.Text; 
            string Password=txt_password.Text;  

            if (txt_password.Text == ""
                || txt_username.Text == "")
            { MessageBox.Show("Required Fields Empty"); }
            //else
            //{

            //    if (chk_rememberMe.Checked == false)
            //    {
            //        using (SqlConnection conn = new SqlConnection(connectionString))
            //        {
            //            try
            //            {
            //                conn.Open();
            //                string query = "select count(1) from useracount where username=@username and pass=@password";
            //                using (SqlCommand cmd = new SqlCommand(query, conn))
            //                {
            //                    cmd.Parameters.AddWithValue("@username",User_Name);
            //                    cmd.Parameters.AddWithValue("@password", Password);
            //                    int rowaffected = Convert.ToInt32(cmd.ExecuteScalar());
            //                    if (rowaffected > 0)
            //                    {
            //                        MessageBox.Show("login successful");
            //                    }
            //                    else
            //                    {
            //                        MessageBox.Show("login failed , try again");
            //                    }


            //                }
            //            }
            //            catch (Exception ex) { MessageBox.Show("errorrrrrr: " + ex.Message); }
            //        }
            //    }
            //}
            user_home user_Home = new user_home();
            user_Home.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            option_for_register option = new option_for_register();
            option.Show();
        }
    }
}
