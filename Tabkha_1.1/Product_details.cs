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
        public Product_details()
        {
            InitializeComponent();
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
            guna2CirclePictureBox1.Image = Image.FromFile(Session.pic);
        }
    }
}
