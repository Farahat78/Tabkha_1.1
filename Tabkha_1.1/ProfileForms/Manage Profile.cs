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
using System.Xml.Linq;
using Tabkha_1._1.Class;

namespace Tabkha_1._1
{
    public partial class Manage_Profile : Form
    {
        public Manage_Profile()
        {
            InitializeComponent();
        }

        public void readOnly()
        {
            txtbox_password.ReadOnly = true;
            txtbox_email.ReadOnly = true;
            txtbox_name.ReadOnly = true;
            txtbox_Pnumber.ReadOnly = true;
            btn_edit_img.Visible = false;
            btn_save.Visible = false;
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            txtbox_password.ReadOnly = false;
            txtbox_email.ReadOnly = false;
            txtbox_name.ReadOnly = false;
            txtbox_Pnumber.ReadOnly = false;
            btn_edit_img.Visible = true;
            btn_save.Visible = true;
        }

        private void LoadUserData()
        {
            Manage_Profile manage = new Manage_Profile();
            string query = "";

            // Determine which table to query based on the role in the session
            if (Session.Role == "Admin")
            {
                query = "SELECT Username, Email, Password FROM Admins WHERE AdminID = @UserID";
            }
            else if (Session.Role == "User")
            {
                query = "SELECT Name, Email, Password FROM Users WHERE UserID = @UserID";
            }
            else if (Session.Role == "Chef")
            {
                query = "SELECT Name, Email, Password FROM Chefs WHERE ChefID = @UserID";
            }

            using (SqlConnection conn = new SqlConnection(Connection.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", Session.Id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtbox_name.Text = reader["Username"].ToString();
                            txtbox_email.Text = reader["Email"].ToString();
                            txtbox_password.Text = reader["Password"].ToString();
                        }
                    }
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            readOnly();
            string query = "";

            // Determine which table to update based on the role in the session
            if (Session.Role == "Admin")
            {
                query = "UPDATE Admins SET Username = @Name, Email = @Email, Password = @Password WHERE AdminID = @UserID";
            }
            else if (Session.Role == "User")
            {
                query = "UPDATE Users SET Name = @Name, Email = @Email, Password = @Password WHERE UserID = @UserID";
            }
            else if (Session.Role == "Chef")
            {
                query = "UPDATE Chefs SET Name = @Name, Email = @Email, Password = @Password WHERE ChefID = @UserID";
            }

            using (SqlConnection conn = new SqlConnection(Connection.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", txtbox_name.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtbox_email.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtbox_password.Text.Trim());
                    cmd.Parameters.AddWithValue("@UserID", Session.Id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Manage_Profile_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }
    }
}
