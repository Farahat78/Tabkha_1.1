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
using Tabkha_1._1.Class;

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
            string pass = txt_password.Text;

            if (pass != txt_confirmPassword.Text) { MessageBox.Show("Password and confirm password do not match , please try again"); }
            else
            {
                string email = globalvariables.global_email;
                using (SqlConnection conn = Connection.Instance.GetConnection())
                {
                    try
                    {
                        if (conn.State == System.Data.ConnectionState.Closed)
                        {
                            conn.Open();
                        }
                        string query = "update Users set Password=@password where Email=@email";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {


                            cmd.Parameters.AddWithValue("@password", pass);
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
        private bool isPasswordVisible = false;

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

        private void btn_eye_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility();
        }
        private string placeholderText1 = "Confirm password"; // Set your placeholder text
        private Color placeholderColor = Color.Gray;  // Light gray for placeholder
        private Color textColor = Color.Black;
        private string placeholderText = "Enter your password";

        private void ResetPassword_Load(object sender, EventArgs e)
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
    }
}

