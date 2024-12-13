using System;
using System.Collections;
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
        private int dishid;
        public uploadnew()
        {
            InitializeComponent();
        }

        public uploadnew(int dishId)
        {
            InitializeComponent();
            this.dishid = dishId; // تخزين الـ DishID المُرسل من صفحة ProductDetails
            LoadDishData(); // تحميل بيانات الطبق
        }
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
                Weight += checkBox1.Text;
            }
            else if(checkBox2.Checked)
            {
                Weight += checkBox2.Text;
            }
            else if(checkBox3.Checked)
            {
                Weight += checkBox3.Text;
            }

            if (checkBox1.Text != "" && checkBox2.Text != "" && checkBox3.Text != "" && txt_description.Text !="" && txt_name.Text !="" && txt_ingredients.Text !="" && n_preptime.Value !=0 && n_quantity.Value !=0 && txt_price.Text !="" && combo_category.Text!="" && img_product.ToString() !="")
            {
                SqlConnection con = new SqlConnection(Connection.connectionString);
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

        public void update()
        {
            string Name = txt_name.Text;
            string Description = txt_description.Text;
            decimal PrepTime = Convert.ToInt64(n_preptime.Value);
            decimal Quantity = Convert.ToInt64(n_quantity.Value);
            string Price = txt_price.Text;
            string Category = combo_category.Text;
            string Ingredients = txt_ingredients.Text;
            string DishPic;

            if (!string.IsNullOrEmpty(currentImagePath))
            {
                DishPic = currentImagePath;
            }
            else
            {
                DishPic = img_product.ImageLocation;
            }



            // تحديد الـ Weight بناءً على الـ Checkboxes
            string Weight = "";
            if (checkBox1.Checked)
            {
                Weight += checkBox1.Text;
            }
            else if (checkBox2.Checked)
            {
                Weight += checkBox2.Text;
            }
            else if (checkBox3.Checked)
            {
                Weight += checkBox3.Text;
            }

            // التأكد من أن جميع الحقول تم ملؤها
            if (checkBox1.Text != "" && checkBox2.Text != "" && checkBox3.Text != "" &&
                txt_description.Text != "" && txt_name.Text != "" && txt_ingredients.Text != "" &&
                n_preptime.Value != 0 && n_quantity.Value != 0 && txt_price.Text != "" &&
                combo_category.Text != "" && img_product.ToString() != "")
            {
                // استعلام الـ UPDATE
                SqlConnection con = new SqlConnection(Connection.connectionString);
                con.Open();

                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Menu] SET DishName = @Name, Price = @Price, DishPic = @DishPic, Quantity = @Quantity, Weight = @Weight, Ingredients = @Ingredients, Category = @Category, PrepTime = @PrepTime, Description = @Description WHERE MenuID = @DishID", con);

                // تمرير القيم إلى الـ SQL Parameters
                cmd.Parameters.AddWithValue("@DishID", dishid);  // تأكد من أن dishId هو ID الطبق الحالي الذي تريد تحديثه
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Description", Description);
                cmd.Parameters.AddWithValue("@Ingredients", Ingredients);
                cmd.Parameters.AddWithValue("@PrepTime", PrepTime);
                cmd.Parameters.AddWithValue("@Quantity", Quantity);
                cmd.Parameters.AddWithValue("@Category", Category);
                cmd.Parameters.AddWithValue("@Price", Price);
                // تأكد إذا كان DishPic فارغًا، وإذا كان كذلك، مرر DBNull.Value
                if (string.IsNullOrEmpty(DishPic))
                {
                    cmd.Parameters.AddWithValue("@DishPic", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DishPic", DishPic);
                }
                cmd.Parameters.AddWithValue("@Weight", Weight);

                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Record Updated Successfully");
            }
            else
            {
                MessageBox.Show("Please provide all details.");
            }
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
            if (dishid == 0)
            {
                insert();
            }
            else
            {
                update();
            }
            
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

        private void LoadDishData()
        {
            string query = "SELECT [DishName],[Description],[Price],[DishPic],[Quantity],[Weight],[Ingredients],[Category],[PrepTime]FROM [dbo].[Menu] where MenuID = @DishID";

            using (SqlConnection con = new SqlConnection(Connection.connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DishID", dishid);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txt_name.Text = reader["DishName"].ToString();
                    txt_description.Text = reader["Description"].ToString();
                    txt_price.Text = reader["Price"].ToString();
                    txt_ingredients.Text = reader["Ingredients"].ToString();
                    combo_category.Text = reader["Category"].ToString();
                    n_preptime.Value = (int)reader["PrepTime"];
                    n_quantity.Value = (int)reader["Quantity"];
                    string imagepath = reader["DishPic"].ToString();
                    if (!string.IsNullOrEmpty(imagepath) && File.Exists(imagepath))
                    {
                        img_product.Image = Image.FromFile(imagepath); // عرض الصورة في الـ PictureBox
                    }
                    
                    string weight = reader["Weight"].ToString();
                    if (weight == "200 gm")
                    {
                        checkBox1.Checked = true;  // حدد الـ Checkbox الأول
                        checkBox2.Checked = false; // إلغاء تحديد الـ Checkbox الثاني
                        checkBox3.Checked = false; // إلغاء تحديد الـ Checkbox الثالث
                    }
                    else if (weight == "400 gm")
                    {
                        checkBox1.Checked = false;
                        checkBox2.Checked = true;
                        checkBox3.Checked = false;
                    }
                    else if (weight == "1 kg")
                    {
                        checkBox1.Checked = false;
                        checkBox2.Checked = false;
                        checkBox3.Checked = true;
                    }
                  

                }
                con.Close();
            }
        }


    }
}
