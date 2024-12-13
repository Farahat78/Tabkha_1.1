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
    public partial class comments : Form
    {
        public comments()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private Control CloneControl(Control control)
        {
            Control newControl = (Control)Activator.CreateInstance(control.GetType());
            newControl.Text = control.Text;
            newControl.Size = control.Size;
            newControl.Location = control.Location;
            newControl.Font = control.Font;
            newControl.BackColor = control.BackColor;
            newControl.ForeColor = control.ForeColor;
            newControl.Name = control.Name;

            // Copy other properties as needed
            return newControl;
        }

        private void LoadReviews()
        {
            try
            {
                string query = @"
                    SELECT 
                        Reviews.ReviewID, 
                        Reviews.Comment, 
                        Reviews.Rating, 
                        Users.Fname, 
                        Users.Lname, 
                        Users.ProfilePic 
                    FROM 
                        Reviews 
                    INNER JOIN 
                        Users 
                    ON 
                        Reviews.UserID = Users.UserID 
                    WHERE 
                        Reviews.ChefID = @ChefID"; // Use the ChefID of the current chef

                using (SqlConnection connection = new SqlConnection(Connection.connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ChefID", Session.Id); // Get the ChefID from the session
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    //flowLayoutPanel1.Controls.Clear(); // Clear existing comments

                    while (reader.Read())
                    {
                        // Clone the existing comment card template
                        Panel newCard = CloneCommentCard();

                        // Update profile picture
                        PictureBox profilePicBox = newCard.Controls.OfType<PictureBox>().FirstOrDefault(c => c.Name == "img_profile");
                        string profilePicPath = reader["ProfilePic"]?.ToString();
                        if (profilePicBox != null)
                        {
                            profilePicBox.Image = !string.IsNullOrEmpty(profilePicPath)
                                ? Image.FromFile(profilePicPath)
                                : Properties.Resources.Max_R_Headshot__1_; // Default image if none provided
                            profilePicBox.SizeMode = PictureBoxSizeMode.Zoom;
                        }

                        // Update name
                        Label nameLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_nme");
                        if (nameLabel != null)
                        {
                            nameLabel.Text = $"{reader["Fname"]} {reader["Lname"]}";
                        }

                        // Update rating (e.g., stars)
                        Label ratingLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "stars");
                        if (ratingLabel != null)
                        {
                            ratingLabel.Text = new string('★', (int)reader["Rating"]); // Display stars based on rating
                        }

                        // Update comment text
                        Label commentLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_comments");
                        if (commentLabel != null)
                        {
                            commentLabel.Text = reader["Comment"].ToString();
                        }

                        // Add the comment card to the FlowLayoutPanel
                        flowLayoutPanel1.Controls.Add(newCard);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading reviews: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CloneCommentCard()
        {
            Panel newCard = new Panel
            {
                Size = panelTemplate.Size,
                BackColor = panelTemplate.BackColor,
                BorderStyle = panelTemplate.BorderStyle
            };

            foreach (Control control in panelTemplate.Controls)
            {
                Control clonedControl = CloneControl(control);
                newCard.Controls.Add(clonedControl);
            }

            return newCard;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
