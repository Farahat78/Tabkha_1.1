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
    public partial class place_order : Form
    {

        public place_order()
        {
            InitializeComponent();
            label29.Text = Session.Name;
            img_profile.Image = !string.IsNullOrEmpty(Session.pic)
           ? Image.FromFile(Session.pic)
           : Properties.Resources.Max_R_Headshot__1_;
            CreateCardsFromCartDatabase();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            TextBox[] textBoxes = { txt_cardnum, txt_expiry, txt_cvv };

            foreach (TextBox txt in textBoxes)
            {
                txt.ReadOnly = true;
                txt.Text = null;
            }

        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            TextBox[] textBoxes = { txt_cardnum, txt_expiry, txt_cvv };
            foreach (TextBox txt in textBoxes)
            {
                txt.ReadOnly = false;      
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
            user_home user_Home = new user_home();
            user_Home.Show();
            this.Hide();
        }

        private void label29_Click(object sender, EventArgs e)
        {
            Customer_Profile customer_Profile = new Customer_Profile(Session.Id);
            customer_Profile.Show();
            this.Hide();
        }


        private void CreateCardsFromCartDatabase()
        {
            // 1. اتصال بقاعدة البيانات
            string query = "SELECT c.[DishID], c.[Quantity], c.[Price], c.[DishPic], c.[Weight], m.[DishName] FROM [tabkha1].[dbo].[Cart] c JOIN [tabkha1].[dbo].[Menu] m ON c.DishID = m.MenuID WHERE c.UserID = @UserID";

            using (SqlConnection connection = Connection.Instance.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", Session.Id); // تمرير UserID في الاستعلام
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // تأكد أن الكارد الأساسي مخفي
                panelTemplate.Visible = false;

                decimal subtotal = 0;
                decimal delivery = 20;
               

                // 2. قراءة البيانات وإنشاء الكروت
                while (reader.Read())
                {
                    // نسخ الكارد الأساسي
                    Panel newCard = new Panel
                    {
                        Size = panelTemplate.Size,
                        BackColor = panelTemplate.BackColor,
                        Tag = reader["DishID"]
                    };

                    foreach (Control control in panelTemplate.Controls)
                    {
                        Control clonedControl = CloneControl(control);
                        newCard.Controls.Add(clonedControl);
                    }

                    // تخصيص البيانات داخل الكارد
                    Label nameLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_product_name");
                    if (nameLabel != null) nameLabel.Text = reader["DishName"].ToString();

                    // الكمية
                    Label quantityLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "label21");
                        int quantity = 0;
                        if (quantityLabel != null)
                        {
                            quantity = Convert.ToInt32(reader["Quantity"]);
                            quantityLabel.Text = quantity.ToString();
                        }

                    // السعر
                    Label priceLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_price");
                    if (priceLabel != null) 
                    {
                        decimal price = Convert.ToDecimal(reader["Price"]);
                        priceLabel.Text = price.ToString() + " EGP";

                        // إضافة السعر إلى الإجمالي
                        subtotal += price * quantity;
                    }
                    // الوزن
                    Label weightLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_wieght");
                    if (weightLabel != null) weightLabel.Text = reader["Weight"].ToString();

                    // صورة الطبق
                    try
                    {
                        PictureBox dishPictureBox = newCard.Controls.OfType<PictureBox>().FirstOrDefault(c => c.Name == "img_product");
                        string imagepath = reader["DishPic"]?.ToString();

                        if (dishPictureBox != null)
                        {
                            if (!string.IsNullOrEmpty(imagepath) && System.IO.File.Exists(imagepath))
                            {
                                dishPictureBox.Image = Image.FromFile(imagepath);
                            }
                            else
                            {
                                dishPictureBox.Image = Properties.Resources.dish; // تعيين صورة افتراضية
                            }

                            dishPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message);
                    }

                    Label removeLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_remove");
                    if (removeLabel != null)
                    {
                        removeLabel.Text = "Remove"; // نص الزر، يمكن تغييره حسب الحاجة
                        removeLabel.ForeColor = Color.Red; // تغيير اللون لجعل الزر يظهر بوضوح
                        removeLabel.Font = new Font(removeLabel.Font, FontStyle.Bold);
                        removeLabel.Cursor = Cursors.Hand; // تغيير المؤشر عند المرور على الزر

                        // ربط حدث الحذف
                        removeLabel.Click += (sender, e) => DeleteItemFromCart((int)newCard.Tag);
                    }

                    // إضافة الكارد إلى الـ FlowLayoutPanel
                    flowLayoutPanel1.Controls.Add(newCard);
                }

                reader.Close();

                decimal total = subtotal + delivery;
                lbl_subtotal.Text = subtotal.ToString()+ " EGP";
                lbl_delivery.Text = delivery.ToString() + " EGP";
                lbl_total.Text = total.ToString()+ " EGP";
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

        private void DeleteItemFromCart(int dishID)
        {
            string query = "DELETE FROM [tabkha1].[dbo].[Cart] WHERE DishID = @DishID AND UserID = @UserID";

            using (SqlConnection connection = Connection.Instance.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DishID", dishID);
                command.Parameters.AddWithValue("@UserID", Session.Id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery(); // تنفيذ الاستعلام
                    MessageBox.Show("Item deleted successfully.");

                    // تحديث الواجهة بعد الحذف
                    // قم بتحديث الـ FlowLayoutPanel لإزالة الكارد المحذوف (إن أردت)
                    flowLayoutPanel1.Controls.Clear();
                    CreateCardsFromCartDatabase(); // إعادة تحميل العناصر بعد الحذف
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting item: " + ex.Message);
                }
            }
        }
        private void AddOrder()
        {
            decimal totalPrice = Convert.ToDecimal(lbl_total.Text.Split(' ')[0]); // الحصول على الإجمالي من lbl_total
            string orderStatus = "new"; // حالة الطلب "جديد"
            int userId = Session.Id; // معرف المستخدم

            // التحقق من طريقة الدفع
            if (radio_cash.Checked)
            {
                // إذا كان الدفع نقدًا عند التوصيل
                InsertOrderIntoDatabase(totalPrice, orderStatus, userId);
            }
            else if (radio_credit.Checked)
            {
                // إذا كان الدفع عن طريق البطاقة الائتمانية
                if (ValidateCreditCard()) // تحقق من صحة البطاقة الائتمانية
                {
                    InsertOrderIntoDatabase(totalPrice, orderStatus, userId);
                }
                else
                {
                    MessageBox.Show("Credit card information is invalid.");
                }
            }
        }

        private void InsertOrderIntoDatabase(decimal totalPrice, string orderStatus, int userId)
        {
            // إضافة الطلب إلى جدول Orders
            string insertOrderQuery = "INSERT INTO [tabkha1].[dbo].[Orders] (UserID, TotalPrice, OrderStatus) OUTPUT INSERTED.OrderID VALUES (@UserID, @TotalPrice, @OrderStatus)";

            using (SqlConnection connection = Connection.Instance.GetConnection())
            {
                SqlCommand command = new SqlCommand(insertOrderQuery, connection);
                command.Parameters.AddWithValue("@UserID", userId);
                command.Parameters.AddWithValue("@TotalPrice", totalPrice);
                command.Parameters.AddWithValue("@OrderStatus", orderStatus);

                try
                {
                    connection.Open();
                    int orderId = (int)command.ExecuteScalar(); // الحصول على OrderID للطلب الذي تم إضافته

                    // إضافة عناصر الطلب إلى جدول OrderItems
                    foreach (Panel card in flowLayoutPanel1.Controls)
                    {
                        int dishID = 0;
                        if (card.Tag != null)
                        {
                            dishID = (int)card.Tag; // الحصول على DishID إذا كان Tag مخصصًا
                        }
                        else
                        {
                            continue; // تخطي الكارد إذا كان الـ Tag فارغًا
                        }

                        Label quantityLabel = card.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "label21");
                        int quantity = Convert.ToInt32(quantityLabel.Text);

                        decimal price = Convert.ToDecimal(card.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_price").Text.Split(' ')[0]);

                        string insertOrderItemQuery = "INSERT INTO [tabkha1].[dbo].[OrderItems] (OrderID, MenuID, Quantity, Price) VALUES (@OrderID, @MenuID, @Quantity, @Price)";

                        SqlCommand orderItemCommand = new SqlCommand(insertOrderItemQuery, connection);
                        orderItemCommand.Parameters.AddWithValue("@OrderID", orderId);
                        orderItemCommand.Parameters.AddWithValue("@MenuID", dishID);
                        orderItemCommand.Parameters.AddWithValue("@Quantity", quantity);
                        orderItemCommand.Parameters.AddWithValue("@Price", price);

                        orderItemCommand.ExecuteNonQuery(); // إضافة عنصر الطلب
                    }

                    // مسح العناصر من جدول Cart بعد إضافة الطلب
                    string deleteCartQuery = "DELETE FROM [tabkha1].[dbo].[Cart] WHERE UserID = @UserID";
                    SqlCommand deleteCartCommand = new SqlCommand(deleteCartQuery, connection);
                    deleteCartCommand.Parameters.AddWithValue("@UserID", userId);
                    deleteCartCommand.ExecuteNonQuery(); // تنفيذ الحذف

                    CreateCardsFromCartDatabase();

                    MessageBox.Show("Order placed successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding order: " + ex.Message);
                }
            }
        }


        private bool ValidateCreditCard()
        {

            if (!string.IsNullOrEmpty(txt_cardnum.Text) && !string.IsNullOrEmpty(txt_expiry.Text) && !string.IsNullOrEmpty(txt_cvv.Text))
            {
                return true; // البطاقة صحيحة
            }

            return false; // البطاقة غير صحيحة
        }

        private void btn_place_order_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_name.Text)&& !string.IsNullOrEmpty(txt_phone.Text)&& !string.IsNullOrEmpty(txt_address.Text)&& !string.IsNullOrEmpty(comboBox1.Text))
            {
                AddOrder();
                flowLayoutPanel1.Controls.Clear();
                CreateCardsFromCartDatabase();
            }
            else
            {
               
                MessageBox.Show("Please complete your Delivery information");
            }
          
        }

        private void img_logo_Click(object sender, EventArgs e)
        {
            user_home user_Home = new user_home();
            user_Home.Show();
            this.Hide();
        }

        private void lbl_logout_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();

            Session.Logout();
        }
    }
}
