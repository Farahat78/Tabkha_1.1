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

            using (SqlConnection connection = Connection.Instance.GetConnection())
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

        private void comments_Load(object sender, EventArgs e)
        {

        }
    }
}
