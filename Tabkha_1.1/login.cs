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
using Tabkha_1._1.Class;
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


                try
                {
                    using (SqlConnection conn = new SqlConnection(Connection.connectionString))
                    {
                        conn.Open();

                        // تحقق من جدول Users
                        UserDetails userId = GetUserDetailsFromTable(conn, "Users","UserID" ,"Fname", user_name, password);
                        if (userId !=null)
                        {
                            Session.Id=userId.UserId;
                            Session.Role = "Users";
                            Session.Name= userId.Name;
                            Session.pic = userId.picpath;


                            user_home userHome = new user_home(); // صفحة المستخدم
                            userHome.Show();
                            this.Hide();
                            return;
                        }

                        // تحقق من جدول Chefs

                        userId = GetUserDetailsFromTable(conn, "Chefs", "ChefID","Fname", user_name, password);
                        if (userId != null)
                        {

                            Session.Id = userId.UserId;
                            Session.Role = "Chefs";
                            Session.Name = userId.Name;
                            Session.pic = userId.picpath;


                            Owner_Profile ownerProfile = new Owner_Profile(); // صفحة الطباخ
                            ownerProfile.Show();
                            this.Hide();
                            return;
                        }

                        // تحقق من جدول Admins

                        userId = GetUserDetailsFromTable(conn, "Admins", "AdminID","Username", user_name, password);
                        if (userId != null)
                        {
                            Session.Id = userId.UserId;
                            Session.Role = "Admins";
                            Session.Name = userId.Name;
                            Session.pic = userId.picpath;

                            Admin adminPage = new Admin(); // صفحة المدير
                            adminPage.Show();
                            this.Hide();
                            return;
                        }

                        // إذا لم يتم العثور على المستخدم
                        MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }




                catch (Exception ex) { MessageBox.Show("errorrrrrr: " + ex.Message); }
                }


            

        }

        public void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            option_for_register option = new option_for_register();
            option.Show();
            this.Hide();
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

            using (SqlConnection conn = new SqlConnection(Connection.connectionString))
            {
                
                
                    conn.Open();
                   
                        query = "select Password from Users where Email=@email ";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {

                             cmd.Parameters.AddWithValue("@email", user_email);
                             using (SqlDataReader reader = cmd.ExecuteReader())
                             {
                                   if(reader.Read())
                                   {
                                        password = reader["Password"].ToString();
                                        

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

        public class UserDetails
        {
            public int UserId { get; set; } // المعرف الفريد
            public string Name { get; set; } // اسم المستخدم

            public string picpath { get; set; }
        }

        private UserDetails GetUserDetailsFromTable(SqlConnection conn, string tableName, string idColumn, string nameColumn, string username, string password)
        {
            string query;
            if (tableName.Equals("Admins", StringComparison.OrdinalIgnoreCase))
            {
                // Query for the admin table (no Phone column)
                query = $"SELECT {idColumn},{nameColumn} ,[ProfilePic] FROM {tableName} WHERE Email = @Username AND Password = @Password";
            }
            else
            {
                // Query for tables with both Email and Phone columns
                query = $"SELECT {idColumn},[Fname], [Lname],[ProfilePic] FROM {tableName} WHERE (Email = @Username OR Phone = @Username) AND Password = @Password";
            }
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string fullName;

                        if (tableName.Equals("Admins", StringComparison.OrdinalIgnoreCase))
                        {
                            // Admin table has a single name column
                            fullName = reader[nameColumn].ToString();
                        }
                        else
                        {
                            // Users and Chefs have FName and LName columns
                            string firstName = reader["FName"].ToString();
                            string lastName = reader["LName"].ToString();
                            fullName = $"{firstName} {lastName}";
                        }

                        return new UserDetails
                        {
                            UserId = Convert.ToInt32(reader[idColumn]),
                            Name = fullName,
                            picpath = reader.FieldCount > reader.GetOrdinal("ProfilePic") ? reader["ProfilePic"].ToString() : null
                        };
                    }
                }
            }
            return null; // Return null if no user is found
        }

        private bool isPasswordVisible = false;

        private void btn_eye_Click(object sender, EventArgs e)
        {
            TogglePasswordVisibility();
        }

        private void TogglePasswordVisibility()
        {
            if (isPasswordVisible)
            {
                // Hide the password
                txt_password.PasswordChar = '*';
                btn_eye.Image = Properties.Resources.eye__1_; // Replace with 'eye closed' icon
                isPasswordVisible = false;
            }
            else
            {
                // Show the password
                txt_password.PasswordChar = '\0';
                btn_eye.Image = Properties.Resources.eye; // Replace with 'eye open' icon
                isPasswordVisible = true;
            }
        }

        private string placeholderText = "Enter your password"; // Set your placeholder text
        private Color placeholderColor = Color.Gray;  // Light gray for placeholder
        private Color textColor = Color.Black;

        private void txt_password_Enter(object sender, EventArgs e)
        {
            if (txt_password.Text == placeholderText)
            {
                txt_password.Text = "";
                txt_password.ForeColor = textColor;

                // Ensure PasswordChar works only when the placeholder is gone
                txt_password.PasswordChar = isPasswordVisible ? '\0' : '*';
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

        private void login_Load(object sender, EventArgs e)
        {
            // Initialize placeholder on form load
            txt_password.Text = placeholderText;
            txt_password.ForeColor = placeholderColor;

            // Disable masking to show placeholder text
            txt_password.PasswordChar = '\0';
        }
    }
}
