using Guna.UI2.WinForms;
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
    public partial class Owner_Profile : Form
    {
        private FlowLayoutPanel FlowLayoutPanel;
        private int chefid ;
        string query;
        public Owner_Profile()
        {
            InitializeComponent();
            Comments();
        }
        public Owner_Profile(int ChefID)
        {
            InitializeComponent();
            chefid = ChefID;
            Comments();
        }
        private void CreateCardsFromDatabase()
        {
            if (Session.Role == "Chefs")
            {
                 query = $"  SELECT  MenuID ,  DishName,   DishPic, Price FROM [tabkha1].[dbo].[Menu] WHERE ChefID = {Session.Id}";
            }
            else
            {
                // 1. اتصال بقاعدة البيانات
                 query = $"  SELECT  MenuID ,  DishName,   DishPic, Price FROM [tabkha1].[dbo].[Menu] WHERE ChefID ={chefid}";
            }
            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // تأكد أن الكارد الأساسي مخفي
                Panel_Template.Visible = false;

                // 2. قراءة البيانات وإنشاء الكروت
                while (reader.Read())
                {
                    // نسخ الكارد الأساسي
                    Panel newCard = new Panel
                    {
                        Size = Panel_Template.Size,
                        BackColor = Panel_Template.BackColor,
                        Tag = reader["MenuID"]

                    };

                    foreach (Control control in Panel_Template.Controls)
                    {
                       
                        Control clonedControl = CloneControl(control);
                        newCard.Controls.Add(clonedControl);
                    }

                    // 3. تخصيص البيانات داخل الكارد
                    Label nameLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "label8");
                    if (nameLabel != null) nameLabel.Text = reader["DishName"].ToString();

                    Label price = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "label7");
                    if (price != null) price.Text = reader["Price"].ToString();

                    


                    // الشعار (Logo)
                    try
                    {
                        PictureBox pic = newCard.Controls.OfType<PictureBox>().FirstOrDefault(c => c.Name == "pictureBox2");
                        string imagepath = reader["DishPic"]?.ToString();

                        if (pic != null)
                        {
                            if (!string.IsNullOrEmpty(imagepath) && System.IO.File.Exists(imagepath))
                            {
                                // إذا كانت الصورة موجودة في المسار
                                pic.Image = Image.FromFile(imagepath);
                            }
                            else
                            {
                                // إذا لم تكن الصورة موجودة أو لم يتم العثور على المسار
                                pic.Image = Properties.Resources.chef; // تعيين null لإظهار InitialImage
                            }

                            pic.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message);
                    }

                    newCard.Click += (s, e) => OpenProductDetails((int)newCard.Tag);
                    // 4. إضافة الكارد الجديد إلى الـ FlowLayoutPanel
                    flowLayoutPanel1.Controls.Add(newCard);
                }

                reader.Close();
            }
        }

        //test
        
        private void Comments()
        {
            label6.Visible = false;
            lbl_usercomment.Visible = false;
            // 1. اتصال بقاعدة البيانات
            string query = "SELECT Users.Fname as fname ,Reviews.Comment  as comment FROM   [tabkha1].[dbo].[Reviews] AS Reviews JOIN  [tabkha1].[dbo].[Users] AS Users  ON Reviews.UserID = Users.UserID WHERE    Reviews.ChefID = @ChefID;";

            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ChefID", chief_id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                int yoffset = 50;
                while (reader.Read())
                {
                    Label username = new Label()
                    {
                        Text = reader["fname"].ToString(), // Set the username from the database‍
                        Font = label6.Font,               // Copy the font from label6
                        ForeColor = label6.ForeColor,     // Copy the text color from label6
                        AutoSize = true,                  // Enable auto-size‍
                        Location = new Point(label6.Location.X, yoffset) // Position at label6's location‍
                    };

                    
                    Label Usercomment = new Label
                    {
                        Text = reader["comment"].ToString(), // Set the comment from the database‍
                        Font = lbl_usercomment.Font,         // Copy the font from lbl_usercomment‍
                        ForeColor = lbl_usercomment.ForeColor, // Copy the text color‍
                        AutoSize = true,                      // Enable auto-size‍
                        Location = new Point(lbl_usercomment.Location.X, yoffset + 30) 
                    };
                    


                    guna2ShadowPanel2.Controls.Add(username);
                    guna2ShadowPanel2.Controls.Add(Usercomment);
                    yoffset += 70;
                }
            }
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


            // نسخ الخصائص الأخرى حسب الحاجة
            return newControl;
        }

        private void OpenProductDetails(int dishId)
        {
            var detailsForm = new Product_details(dishId, chefid);
            detailsForm.Show();
            this.Hide(); // إذا أردت إخفاء الصفحة الحالية
        }




        private void ChangeColor(Button btn, Button btn2, Button btn3, Button btn4 , Button btn5)
        {
            btn.BackColor = Color.FromArgb(236, 172, 124);
            btn2.BackColor = Color.FromArgb(204, 82, 48);
            btn3.BackColor = Color.FromArgb(204, 82, 48);
            btn4.BackColor = Color.FromArgb(204, 82, 48);
            btn5.BackColor = Color.FromArgb(204, 82, 48);

            btn.ForeColor = Color.Black;
            btn2.ForeColor = Color.White;
            btn3.ForeColor = Color.White;
            btn4.ForeColor = Color.White;
            btn5.ForeColor = Color.White;
        }
        private void img_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void img_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_appitizer_Click(object sender, EventArgs e)
        {
            ChangeColor(btn_appitizer, btn_dessert, btn_mainCourse, btn_salad, btn_soup);
        }

        private void btn_mainCourse_Click(object sender, EventArgs e)
        {
            ChangeColor(btn_mainCourse, btn_appitizer, btn_dessert, btn_salad, btn_soup);
        }

        private void btn_soup_Click(object sender, EventArgs e)
        {
            ChangeColor(btn_soup,btn_appitizer, btn_dessert, btn_mainCourse, btn_salad);
        }

        private void btn_salad_Click(object sender, EventArgs e)
        {
            ChangeColor(btn_salad,btn_appitizer, btn_dessert, btn_mainCourse, btn_soup);
        }

        private void btn_dessert_Click(object sender, EventArgs e)
        {
            ChangeColor(btn_dessert,btn_appitizer, btn_mainCourse, btn_salad, btn_soup);
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Customer_Profile ownerProfile = new Customer_Profile(Session.Id);
            ownerProfile.hideSome();
            ownerProfile.Show();
            this.Hide();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            uploadnew uploadnew = new uploadnew();
            uploadnew.Show();
            this.Hide();
        }

        private void Owner_Profile_Load(object sender, EventArgs e)
        {
            CreateCardsFromDatabase();
        }

        private void img_back_Click(object sender, EventArgs e)
        {
            if (Session.Role == "Users")
            {
                user_home home = new user_home();
                home.Show();
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
}
