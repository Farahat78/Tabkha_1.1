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
        public string SName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

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
        int currentUserID = Session.Id;
        private void btn_save_Click(object sender, EventArgs e)
        {
            readOnly();
            using (SqlConnection conn = new SqlConnection(Connection.connectionString))
            {
                conn.Open();
                string query = $"UPDATE {Session.Role} SET Name = @Name, Email = @Email, Password = @Password WHERE {Session.Id} = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", txtbox_name.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtbox_email.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtbox_password.Text.Trim());
                    cmd.Parameters.AddWithValue("@UserID", currentUserID);

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
            txtbox_email.Text = Email;
            txtbox_name.Text = Name;
            txtbox_password.Text = Password;
        }
    }
}
