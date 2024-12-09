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
            place_order place_Order = new place_order();
            place_Order.Show();
            this.Hide();
        }

        private void img_back_Click(object sender, EventArgs e)
        {
            Owner_Profile owner_Profile = new Owner_Profile();
            owner_Profile.Show();
            this.Hide();
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
           
            label11.Text = Session.Name;
            //if (Session.pic != null)
            //{
            //    guna2CirclePictureBox1.Image = Image.FromFile(Session.pic);
            //}
            //else
            //{
            //    guna2CirclePictureBox1.Image = Properties.Resources.Max_R_Headshot__1_;
            //}
            guna2CirclePictureBox1.Image = Properties.Resources.Max_R_Headshot__1_;
        }

        private void Insertcomment()
        {
            float rate = guna2RatingStar1.Value;
            string comment = txt_addcomment.Text;
            int userid = Session.Id;
            int chefid = ChefID;
            if (txt_addcomment.Text != "" || guna2RatingStar1.Value==0)
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

        }

        private void btn_submib_Click(object sender, EventArgs e)
        {
            Insertcomment();
        }
    }
}
