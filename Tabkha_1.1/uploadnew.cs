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

namespace Tabkha_1._1
{
    public partial class uploadnew : Form
    {
        public void insert()
        {
            string Name =txt_name.Text;
            string Description =txt_description.Text;
            decimal PrepTime = Convert.ToInt64(n_preptime.Value);
            decimal Quantity = Convert.ToInt64(n_quantity.Value);
            string Price = txt_price.Text;
            string Category = combo_category.Text;
            string Ingredients = txt_ingredients.Text;
            string DishPic = currentImagePath;
            

            string Weight = "";
            if (checkBox1.Checked)
            {
                Weight += checkBox1.Checked.ToString();
            }
            else if(checkBox2.Checked)
            {
                Weight += checkBox2.Checked.ToString();
            }
            else if(checkBox3.Checked)
            {
                Weight += checkBox3.Checked.ToString();
            }

            if (checkBox1.Text != "" && checkBox2.Text != "" && checkBox3.Text != "" && txt_description.Text !="" && txt_name.Text !="" && txt_ingredients.Text !="" && n_preptime.Value !=0 && n_quantity.Value !=0 && txt_price.Text !="" && combo_category.Text!="" && img_product.ToString() !="")
            {
                SqlConnection con = new SqlConnection(connect.connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into [dbo].[Menu] (ChefID,DishName,Price,DishPic,Quantity,Weight,Ingredients,Category,PrepTime,Description) values(@ChefID,@Name,@Price,@DishPic,@Quantity,@Weight,@Ingredients,@Category,@PrepTime,@Description)", con);
                cmd.Parameters.AddWithValue("@ChefID", Session.Id);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Ingredients", Ingredients);
                cmd.Parameters.AddWithValue("@PrepTime", PrepTime);
                cmd.Parameters.AddWithValue("@Quantity", Quantity);
                cmd.Parameters.AddWithValue("@Category", Category);
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.Parameters.AddWithValue("@DishPic",DishPic);
                cmd.Parameters.AddWithValue("@Weight", Weight);

                cmd.ExecuteNonQuery();
               
                con.Close();
                MessageBox.Show("Record Inserted Successfully");
            }
            else
            {
                MessageBox.Show("please provide details");
            }
        }

        public uploadnew()
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Owner_Profile owner_Profile = new Owner_Profile();
            owner_Profile.Show();
            this.Hide();
        }

        private void uploadnew_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            insert();
            
        }

        private string currentImagePath = string.Empty; 

        private void btn_uploadphoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select an Image",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentImagePath = openFileDialog.FileName;
                img_product.Image = new Bitmap(currentImagePath);
            }
        
        }

    
    }
}
