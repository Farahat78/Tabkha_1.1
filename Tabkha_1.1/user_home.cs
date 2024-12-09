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
    public partial class user_home : Form
    {
        public user_home()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void img_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void check_breakfast_CheckedChanged(object sender, EventArgs e)
        {
            if (check_breakfast.Checked || check_bakery.Checked || check_lunch.Checked || check_dessert.Checked || check_drinks.Checked)
            {
                btn_apply.Enabled = true;
                btn_apply.BackColor = Color.FromArgb(204, 82, 48);
            }
            else
            {
                btn_apply.Enabled = false;
                btn_apply.BackColor = Color.Gray;
            }
        }

        private void user_home_Load(object sender, EventArgs e)
        {
            lbl_account.Text = Session.Name;
            btn_apply.Enabled = false;
            btn_apply.BackColor = Color.Gray;
            CreateCardsFromDatabase();
        }

        private void label2_Click(object sender, EventArgs e)
        {
           place_order place_Order = new place_order();
            place_Order.Show();
            this.Hide();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            Customer_Profile customer_Profile = new Customer_Profile(Session.Id);
            customer_Profile.Show();
            this.Hide();
        }

        private void lbl_logout_Click(object sender, EventArgs e)
        {
            Session.Logout();

            login login = new login();
            login.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
        }

        private void lbl_resname_Click(object sender, EventArgs e)
        {
            Owner_Profile owner_Profile = new Owner_Profile();
            owner_Profile.Show();
            this.Hide();
        }

        private void CreateCardsFromDatabase()
        {
            // 1. اتصال بقاعدة البيانات
            string query = "SELECT [ChefID],[Phone],[ProFilePic],[Rname],[Bio] FROM [tabkha1].[dbo].[Chefs]";

            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // تأكد أن الكارد الأساسي مخفي
                panelTemplate.Visible = false;

                // 2. قراءة البيانات وإنشاء الكروت
                while (reader.Read())
                {
                    // نسخ الكارد الأساسي
                    Panel newCard = new Panel
                    {
                        Size = panelTemplate.Size,
                        BackColor = panelTemplate.BackColor,
                        Tag = reader["ChefID"]
                        
                    };

                    foreach (Control control in panelTemplate.Controls)
                    {
                        Control clonedControl = CloneControl(control);
                        newCard.Controls.Add(clonedControl);
                    }

                    // 3. تخصيص البيانات داخل الكارد
                    // اسم المطعم
                    Label nameLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_resname");
                    if (nameLabel != null) nameLabel.Text = reader["Rname"].ToString();

                    // phone
                    Label phone = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_phone");
                    if (phone != null) phone.Text= reader["Phone"].ToString();

                    Label categoryLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_bio");
                    if (categoryLabel != null)
                        categoryLabel.Text = reader["Bio"].ToString();

                    // الشعار (Logo)
                    try
                    {
                        PictureBox logoPictureBox = newCard.Controls.OfType<PictureBox>().FirstOrDefault(c => c.Name == "img_reslogo");
                        string imagepath = reader["ProFilePic"]?.ToString();

                        if (logoPictureBox != null)
                        {
                            if (!string.IsNullOrEmpty(imagepath) && System.IO.File.Exists(imagepath))
                            {
                                // إذا كانت الصورة موجودة في المسار
                                logoPictureBox.Image = Image.FromFile(imagepath);
                            }
                            else
                            {
                                // إذا لم تكن الصورة موجودة أو لم يتم العثور على المسار
                                logoPictureBox.Image = Properties.Resources.chef; // تعيين null لإظهار InitialImage
                            }

                            logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message);
                    }

                    newCard.Click += (s, e) => OpenRestaurant((int)newCard.Tag);
                    // 4. إضافة الكارد الجديد إلى الـ FlowLayoutPanel
                    flowLayoutPanel1.Controls.Add(newCard);
                }

                reader.Close();
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

        private void OpenRestaurant(int ChefID)
        {
            var restaurant = new Owner_Profile(ChefID);
            restaurant.Show();
            this.Hide(); // إذا أردت إخفاء الصفحة الحالية
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string searchQuery = txt_search.Text.Trim().ToLower(); // الحصول على النص المدخل
            foreach (Panel card in flowLayoutPanel1.Controls.OfType<Panel>())
            {
                // ابحث عن العنصر المطلوب داخل الكارت
                Label nameLabel = card.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_resname");

                if (nameLabel != null && nameLabel.Text.ToLower().Contains(searchQuery))
                {
                    card.Visible = true; // إظهار الكارت إذا كان يطابق النص
                }
                else
                {
                    card.Visible = false; // إخفاء الكارت إذا لم يكن يطابق النص
                }
            }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_search.Text))
            {
                foreach (Panel card in flowLayoutPanel1.Controls.OfType<Panel>())
                {
                    panelTemplate.Visible= false;
                    card.Visible = true; // إعادة إظهار جميع الكروت
                }
            }
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
