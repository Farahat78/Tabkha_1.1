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
            if (Session.Role == "Admins")
            {
                query = "SELECT Username, Email, Password, ProfilePic FROM Admins WHERE AdminID = @UserID";
            }
            else if (Session.Role == "Users")
            {
                query = "SELECT Fname, Lname, Email, Phone, Password, ProfilePic FROM Users WHERE UserID = @UserID";
            }
            else if (Session.Role == "Chefs")
            {
                query = "SELECT Fname, Lname, Email, Phone, Password, ProfilePic FROM Chefs WHERE ChefID = @UserID";
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
                            if (Session.Role == "Admins")
                            {
                                txtbox_name.Text = reader["Username"].ToString();
                            }
                            else
                            {
                                // Combine FName and LName for Users and Chefs
                                txtbox_name.Text = $"{reader["Fname"]} {reader["Lname"]}";
                                txtbox_Pnumber.Text = reader["Phone"].ToString();
                            }
                            txtbox_email.Text = reader["Email"].ToString();
                            txtbox_password.Text = reader["Password"].ToString();
                            pic_pro.ImageLocation = reader["ProfilePic"].ToString();
                        }
                    }
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            readOnly();
            string query = "";

            if (Session.Role == "Admins")
            {
                query = "UPDATE Admins SET Username = @Name, Email = @Email, Password = @Password, ProfilePic = @ProfilePic WHERE AdminID = @UserID";
            }
            else if (Session.Role == "Users")
            {
                query = "UPDATE Users SET Fname = @FName, Lname = @LName, Email = @Email, Password = @Password, ProfilePic = @ProfilePic, Phone = @PhoneNumber WHERE UserID = @UserID";
            }
            else if (Session.Role == "Chefs")
            {
                query = "UPDATE Chefs SET Fname = @FName, Lname = @LName, Email = @Email, Password = @Password, ProfilePic = @ProfilePic, Phone = @PhoneNumber WHERE ChefID = @UserID";
            }

            using (SqlConnection conn = new SqlConnection(Connection.connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (Session.Role == "Admins")
                    {
                        cmd.Parameters.AddWithValue("@Name", txtbox_name.Text.Trim());
                    }
                    if (Session.Role == "Users" || Session.Role == "Chefs")
                    {
                        string[] names = txtbox_name.Text.Trim().Split(' ');
                        cmd.Parameters.AddWithValue("@FName", names.Length > 0 ? names[0] : "");
                        cmd.Parameters.AddWithValue("@LName", names.Length > 1 ? names[1] : "");
                        cmd.Parameters.AddWithValue("@PhoneNumber", txtbox_Pnumber.Text.Trim());
                    }
                    cmd.Parameters.AddWithValue("@Email", txtbox_email.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtbox_password.Text.Trim());
                    cmd.Parameters.AddWithValue("@ProfilePic", Session.pic);
                    cmd.Parameters.AddWithValue("@UserID", Session.Id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        string[] names = txtbox_name.Text.Trim().Split(' ');
                        Session.Name = names.Length > 0
                            ? names[0] + (names.Length > 1 ? " " + names[1] : "")
                            : "";
                        if (this.Owner is Customer_Profile customerProfile)
                        {
                            customerProfile.RefreshProfile(); // Update the profile dynamically
                        }
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

        public void LoadProfilePicture(string picturePath)
        {
            if (!string.IsNullOrEmpty(picturePath))
            {
                pic_pro.ImageLocation = picturePath; // Display the current picture
            }
            else
            {
                pic_pro.Image = null; // Or set a default image if the path is empty
            }
        }

        private string currentImagePath = string.Empty;
        private void btn_edit_img_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"; // Filter for image files
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Update the PictureBox to show the selected image
                    pic_pro.ImageLocation = ofd.FileName;

                    // Save the selected image path in the session
                    Session.pic = ofd.FileName;

                    // Optionally: Update the Profile Picture path in the database immediately
                    string updatePicQuery = "";
                    if (Session.Role == "Admins")
                    {
                        updatePicQuery = "UPDATE Admins SET ProfilePic = @ProfilePic WHERE AdminID = @UserID";
                    }
                    else if (Session.Role == "Users")
                    {
                        updatePicQuery = "UPDATE Users SET ProfilePic = @ProfilePic WHERE UserID = @UserID";
                    }
                    else if (Session.Role == "Chefs")
                    {
                        updatePicQuery = "UPDATE Chefs SET ProfilePic = @ProfilePic WHERE ChefID = @UserID";
                    }

                    using (SqlConnection conn = new SqlConnection(Connection.connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(updatePicQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@ProfilePic", Session.pic);
                            cmd.Parameters.AddWithValue("@UserID", Session.Id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Profile picture updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}