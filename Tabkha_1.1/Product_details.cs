using System;
using System.Collections;
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
    public partial class Product_details : Form
    {

        private int MenuID;
        private int ChefID;
        private void Load_all_page_data()
        {

            string query = $"SELECT [MenuID],[ChefID],[DishName],[Description],[Price],[DishPic],[Quantity],[Weight],[Ingredients],[Category],[PrepTime]FROM [tabkha1].[dbo].[Menu] where MenuID={MenuID}";

            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@menuid", MenuID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string dishname = reader["DishName"].ToString();
                    string Description = reader["Description"].ToString();
                    decimal Price = (decimal)reader["Price"];
                    string DishPic = reader["DishPic"].ToString();

                    string Ingredients = reader["Ingredients"].ToString();
                    string Category = reader["Category"].ToString();
                    int PrepTime = (int)reader["PrepTime"];
                    int quantity = (int)reader["Quantity"];

                    if (quantity > 0)
                    {
                        lbl_available.Visible = false;
                        label3.Visible = true;
                    }
                    else
                    {
                        lbl_available.Visible = true;
                        label3.Visible = false;
                    }

                    img_product.ImageLocation = DishPic;
                    lbl_product_name.Text = dishname;
                    lbl_product_description.Text = Description;
                    lbl_price.Text = Price.ToString();
                    lbl_preparationtime.Text = PrepTime.ToString();
                    label2.Text = Ingredients;
                    lnk_category.Text = Category;
                }
            }
        }
        public Product_details(int menuid, int chefid)
        {
            InitializeComponent();

            MenuID = menuid;
            Load_all_page_data();
            ChefID = chefid;

            label11.Text = Session.Name;
            guna2CirclePictureBox1.Image = !string.IsNullOrEmpty(Session.pic)
                       ? Image.FromFile(Session.pic)
                       : Properties.Resources.Max_R_Headshot__1_;

            if (Session.Role == "Chefs")
            {
                btn_addtocart.Visible = false;
                btn_Edit.Visible = true;
                lbl_Cart.Visible = false;
            }
            else if (Session.Role=="Users")
            {
                btn_addtocart.Visible=true;
                btn_Edit.Visible=false;
                lbl_Cart.Visible=true;
            }
            Comments();
        }

        private void img_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void img_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_order_Click(object sender, EventArgs e)
        {
            uploadnew uploadPage = new uploadnew(MenuID);
            uploadPage.Show();
            this.Hide();
        }

        private void img_back_Click(object sender, EventArgs e)
        {
            if (Session.Role == "Users")
            {
                Owner_Profile owner_Profile = new Owner_Profile(ChefID);
                owner_Profile.Show();
                this.Hide();
            }
            else if (Session.Role == "Chefs")
            {
                Owner_Profile owner_Profile2 = new Owner_Profile();
                owner_Profile2.Show();
                this .Hide();
            }
          
        }

        private void lbl_product_description_Click(object sender, EventArgs e)
        {
            string description = "";
            string dishname = "";

            using (SqlConnection conn = new SqlConnection(Connection.connectionString))
            {
                conn.Open();

                string query = "select Description from Menu where DishName=@dname ";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@dname", dishname);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            description = reader["Description"].ToString();


                        }

                    }


                }
            }
            lbl_product_description.Text = description;
        }

        private void Product_details_Load(object sender, EventArgs e)
        {

            DisplayQuantity(MenuID);
        }

        private void Insertcomment()
        {
            float rate = guna2RatingStar1.Value;
            string comment = txt_addcomment.Text;
            int userid = Session.Id;
            int chefid = ChefID;
            if (txt_addcomment.Text != "" && guna2RatingStar1.Value!=0)
            {
                SqlConnection con = new SqlConnection(Connection.connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into [dbo].[Reviews] (UserID,ChefID,Rating,Comment) values(@userid,@chefid,@rating,@comment)", con);
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@chefid", chefid);
                cmd.Parameters.AddWithValue("@rating", rate);
                cmd.Parameters.AddWithValue("@comment", comment);

                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Thanks For Your Review");
            }
            else
            {
                MessageBox.Show("please Rate And Comment");
            }
        }
        private void insertintocart()
        {
            string dishpic = img_product.ImageLocation.ToString();
            string productname = lbl_product_name.Text;
            string price = lbl_price.Text;
            int quantity = (int)num_quantity.Value;
            int userid = Session.Id ;
            int dishid = MenuID;
            string wheight = "";

            if (radio_wieght.Checked)
            {
                wheight = radio_wieght.Text; // أو أي قيمة مخصصة تريدها
            }
            else if (radioButton2.Checked)
            {
                wheight = radioButton2.Text;
            }
            else if (radioButton3.Checked)
            {
                wheight = radioButton3.Text;
            }

            if (num_quantity.Value != 0 && wheight != "")
            {
                using (SqlConnection con = new SqlConnection(Connection.connectionString))
                {
                    con.Open();

                    // التحقق من الكمية المتوفرة
                    SqlCommand checkCmd = new SqlCommand("SELECT Quantity FROM [dbo].[Menu] WHERE MenuID = @dishid", con);
                    checkCmd.Parameters.AddWithValue("@dishid", dishid);


                    int availableQuantity = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (availableQuantity >= quantity)
                    {
                        // إدخال الطلب في جدول Cart
                        SqlCommand insertCmd = new SqlCommand("INSERT INTO [dbo].[Cart] (UserID, DishID, Quantity, Price, DishPic , weight) VALUES (@userid, @dishid, @quantity, @price, @dishpic , @weight)", con);
                        insertCmd.Parameters.AddWithValue("@userid", userid);
                        insertCmd.Parameters.AddWithValue("@dishid", dishid);
                        insertCmd.Parameters.AddWithValue("@quantity", quantity);
                        insertCmd.Parameters.AddWithValue("@price", price);
                        insertCmd.Parameters.AddWithValue("@dishpic", dishpic);
                        insertCmd.Parameters.AddWithValue("@weight" , wheight);
                        insertCmd.ExecuteNonQuery();

                        // تحديث الكمية المتوفرة في جدول Menu
                        SqlCommand updateCmd = new SqlCommand("UPDATE [dbo].[Menu] SET Quantity = Quantity - @quantity WHERE MenuID = @dishid", con);
                        updateCmd.Parameters.AddWithValue("@quantity", quantity);
                        updateCmd.Parameters.AddWithValue("@dishid", dishid);
                        updateCmd.ExecuteNonQuery();

                        MessageBox.Show("Added to Cart Successfully");

                        DisplayQuantity(MenuID);
                    }
                    else
                    {
                        MessageBox.Show("Sorry, the available quantity is less than your request.");
                    }

                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Choose Wheight and Quantity");
            }


        }

        private void DisplayQuantity(int dishId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connection.connectionString))
                {
                    con.Open();

                    // الاستعلام لجلب الكمية
                    string query = "SELECT Quantity FROM [dbo].[Menu] WHERE MenuID = @dishId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@dishId", dishId);

                    // تنفيذ الاستعلام وجلب الكمية
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        int quantity = Convert.ToInt32(result); // تحويل القيمة إلى عدد صحيح
                        label10.Text = $"Available Quantity: {quantity}"; // عرض الكمية في الـ Label
                    }
                    else
                    {
                        label10.Text = "Dish not found."; // إذا لم يتم العثور على الطبق
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}"); // عرض رسالة في حالة وجود خطأ
            }
        }

        private void Comments()
        {
            label15.Visible = false;
            lbl_comment.Visible = false;
            guna2RatingStar2.Visible= false;
            // 1. اتصال بقاعدة البيانات
            string query = "SELECT  Users.Fname AS fname,  Reviews.Comment AS comment, Reviews.Rating AS rating FROM [tabkha1].[dbo].[Reviews] AS Reviews JOIN  [tabkha1].[dbo].[Users] AS Users ON  Reviews.UserID = Users.UserID WHERE  Reviews.ChefID = @ChefID;";

            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ChefID", ChefID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                int yoffset = 590;
                while (reader.Read())
                {
                    Label username = new Label()
                    {
                        Text = reader["fname"].ToString(), // Set the username from the database‍
                        Font = label15.Font,               // Copy the font from label6
                        ForeColor = label15.ForeColor,     // Copy the text color from label6
                        AutoSize = true,                  // Enable auto-size‍
                        Location = new Point(label15.Location.X, yoffset) // Position at label6's location‍
                    };


                    Label Usercomment = new Label
                    {
                        Text = reader["comment"].ToString(), // Set the comment from the database‍
                        Font = lbl_comment.Font,         // Copy the font from lbl_usercomment‍
                        ForeColor = lbl_comment.ForeColor, // Copy the text color‍
                        AutoSize = true,                      // Enable auto-size‍
                        Location = new Point(lbl_comment.Location.X, yoffset)
                    };
                    Guna.UI2.WinForms.Guna2RatingStar UserRating = new Guna.UI2.WinForms.Guna2RatingStar
                    {
                        Value = reader["Rating"] != DBNull.Value ? Convert.ToSingle(reader["Rating"]) : 0f, // تعيين التقييم من قاعدة البيانات
                        AutoSize = false,
                        RatingColor = Color.FromArgb(255, 128, 0),
                        ReadOnly = true,
                        Size = new Size(89, 28),
                        Location = new Point(guna2RatingStar2.Location.X, yoffset) // ضبط الموقع أسفل التعليق
                    };
                    this.Controls.Add(username);
                    this.Controls.Add(Usercomment);
                    this.Controls.Add(UserRating);
                    yoffset += 40;
                }
            }
        }




        private void btn_submib_Click(object sender, EventArgs e)
        {
            Insertcomment();
            Comments();
        }

        private void btn_addtocart_Click(object sender, EventArgs e)
        {
            insertintocart();
        }

        private void lbl_Cart_Click(object sender, EventArgs e)
        {
            place_order place_Order = new place_order();
            place_Order.Show();
            this.Hide();
        }

        private void lbl_logout_Click(object sender, EventArgs e)
        {
            Session.Logout();

            login login = new login();
            login.Show();
            this.Hide();
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
