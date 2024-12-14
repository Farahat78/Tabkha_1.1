using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tabkha_1._1.Class;
using Tabkha_1._1.Properties;

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

            // Clone other properties if necessary (e.g., events, etc.)
            return newControl;
        }


        private void LoadReviews()
        {
            lbl_nme.Visible = false;
            lbl_comments.Visible = false;
            stars.Visible = false;
            img_profile.Visible = false;

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
                    flowLayoutPanel1.Controls.Clear(); // Clear any previous reviews

                    int yoffset = 50; // Initial vertical offset for positioning controls

                    while (reader.Read())
                    {
                        // Clone the entire comment card (panel) template
                        Panel newCard = CloneCommentCard();

                        // Retrieve and update the profile picture
                        PictureBox imgPic = newCard.Controls.OfType<PictureBox>().FirstOrDefault(c => c.Name == "img_profile");
                        string profilePicPath = reader["ProfilePic"]?.ToString();
                        if (imgPic != null)
                        {
                            imgPic.Image = !string.IsNullOrEmpty(profilePicPath) ? Image.FromFile(profilePicPath) : Properties.Resources.Max_R_Headshot__1_;
                            imgPic.SizeMode = PictureBoxSizeMode.Zoom;
                        }

                        // Update the username label
                        Label nameLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_nme");
                        if (nameLabel != null)
                        {
                            nameLabel.Text = $"{reader["Fname"]} {reader["Lname"]}";
                        }

                        // Update the comment label
                        Label commentLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_comments");
                        if (commentLabel != null)
                        {
                            commentLabel.Text = reader["Comment"].ToString();
                        }

                        // Update the rating star control
                        Guna.UI2.WinForms.Guna2RatingStar userRating = newCard.Controls.OfType<Guna.UI2.WinForms.Guna2RatingStar>().FirstOrDefault(c => c.Name == "stars");
                        if (userRating != null)
                        {
                            userRating.Value = reader["Rating"] != DBNull.Value ? Convert.ToSingle(reader["Rating"]) : 0f;
                        }

                        // Add the cloned card to the FlowLayoutPanel
                        flowLayoutPanel1.Controls.Add(newCard);

                        // Update the vertical offset for the next comment
                        yoffset += 70; // Adjust this value based on your layout
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
            // Create a new panel (cloning the template's properties)
            Panel newCard = new Panel
            {
                Size = panelTemplate.Size, // Clone the size of the panel template
                BackColor = panelTemplate.BackColor, // Clone background color
                BorderStyle = panelTemplate.BorderStyle // Clone border style
            };

            // Clone each control from the template and add to the new panel
            foreach (Control control in panelTemplate.Controls)
            {
                Control clonedControl = CloneControl(control); // Clone each control
                newCard.Controls.Add(clonedControl); // Add the cloned control to the new card
            }

            return newCard;
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comments_Load(object sender, EventArgs e)
        {
            LoadReviews();
        }

        public void LoadComments(int chefId)
        {
            string query = @"
        SELECT 
            users.Fname + ' ' + users.Lname AS username,
            users.ProfilePic,
            reviews.Rating,
            reviews.Comment
        FROM Reviews
        JOIN Users ON Reviews.UserID = Users.UserID
        WHERE Reviews.ChefID = @ChefID
    ";

            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ChefID", chefId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // مسح التعليقات القديمة قبل إضافة الجدد
                flowLayoutPanel1.Controls.Clear();

                while (reader.Read())
                {
                    Panel newPanel = new Panel
                    {
                        Size = pnl_template.Size,
                        BackColor = pnl_template.BackColor
                    };

                    // نسخ كل الكontrolات من الـ PanelTemplate
                    foreach (Control control in pnl_template.Controls)
                    {
                        Control clonedControl = CloneControl(control);
                        newPanel.Controls.Add(clonedControl);
                    }

                    // تعبئة البيانات
                    Label nameLabel = newPanel.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_username");
                    if (nameLabel != null) nameLabel.Text = reader["username"].ToString();

                    // إضافة صورة الملف الشخصي
                    PictureBox profilePic = newPanel.Controls.OfType<PictureBox>().FirstOrDefault(c => c.Name == "img_profile");
                    if (profilePic != null)
                    {
                        profilePic.SizeMode = PictureBoxSizeMode.Zoom;
                        string profilePicPath = reader["ProfilePic"].ToString();
                        if (!string.IsNullOrEmpty(profilePicPath) && File.Exists(profilePicPath))
                        {
                            // Assign the image path to the PictureBox or Guna2PictureBox control
                            profilePic.Image = Image.FromFile(profilePicPath);
                        }
                        else
                        {
                            // If the path is invalid or empty, you can set a default image
                            profilePic.Image = Properties.Resources.Max_R_Headshot__1_; // Ensure you have a default image in your resources
                        }
                        ApplyElipseToImage(profilePic);
                    }

                    // إضافة التقييم
                    Guna.UI2.WinForms.Guna2RatingStar ratingStar = newPanel.Controls.OfType<Guna.UI2.WinForms.Guna2RatingStar>().FirstOrDefault(c => c.Name == "guna2RatingStar1");
                    if (ratingStar != null)
                    {
                        ratingStar.Value = Convert.ToSingle(reader["Rating"]);
                        ratingStar.ReadOnly = true;
                        ratingStar.RatingColor = Color.Yellow;
                    }

                    // إضافة التعليق
                    Label commentLabel = newPanel.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_comments");
                    if (commentLabel != null)
                    {
                        commentLabel.Text = reader["Comment"].ToString();
                    }

                    // إضافة الـ Panel الجديد إلى FlowLayoutPanel
                    flowLayoutPanel1.Controls.Add(newPanel);
                }

                reader.Close();
            }
        }

        // دالة لنسخ الكontrolات
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
            return newControl;
        }

        private void ApplyElipseToImage(PictureBox profilePic)
        {
            // Create a new Guna2Elipse for the PictureBox
            Guna2Elipse elipse = new Guna2Elipse();

            // Set the target control for the elipse
            elipse.TargetControl = profilePic;

            // Set the radius of the ellipse (this will round the corners)
            elipse.BorderRadius = 100; // You can adjust this for more or less rounding

            // Optionally, you can set other properties like the border color, if needed
            // elipse.BorderColor = Color.Gray;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
