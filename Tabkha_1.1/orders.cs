using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tabkha_1._1.Class;

namespace Tabkha_1._1
{
    public partial class orders : Form
    {

        private string printContent;
        public orders()
        {
            InitializeComponent();
            CreateOrderCardsFromDatabase("new");
        }

        private void btn_View_order_Click(object sender, EventArgs e)
        {
            pnl_order_details.Visible = true;
            Button clickedButton = sender as Button;
            if (clickedButton != null && clickedButton.Tag != null)
            {
                int orderId = Convert.ToInt32(clickedButton.Tag);

                // استدعاء وظيفة لتحميل بيانات الطلب من قاعدة البيانات وعرضها
                LoadOrderDetailsToPanel(orderId);
            }

        }

        private void img_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void img_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lbl_myacc_Click(object sender, EventArgs e)
        {
            Owner_Profile owner_Profile = new Owner_Profile();
            owner_Profile.Show();
            this.Hide();
        }

        private void btn_acceptorder_Click(object sender, EventArgs e)
        {
        if (btn_acceptorder.Text == "Accept Order")
            {
                UpdateOrderStatus("Pending");
              
            }
        else if (btn_acceptorder.Text == "Done")
            {
                UpdateOrderStatus("Done");
            }
        else if (btn_acceptorder.Text == "Print Receipt")
            {
                    PrintReceipt();
            }
           
        }

        private void btn_neworders_Click(object sender, EventArgs e)
        {
            btn_acceptorder.Text = "Accept Order";
            btn_acceptorder.BackColor = Color.FromArgb(204, 82, 48);
            pnl_order_details.Visible = false;
            lbl_status.Text = "New Orders";
            flowLayoutPanel1.Controls.Clear();
            CreateOrderCardsFromDatabase("new");
        }

        private void CreateOrderCardsFromDatabase(string status)
        {
            string query = @"
    SELECT 
        users.Fname + ' ' + users.Lname AS username,
        users.Phone,
        users.Address,
        orders.OrderID AS orderid,
        STRING_AGG(Menu.DishName, CHAR(10)) AS DishNames,
        STRING_AGG(CAST(OrderItems.Quantity AS NVARCHAR), CHAR(10)) AS Quantities,
        STRING_AGG(CAST(OrderItems.Price AS NVARCHAR), CHAR(10)) AS Prices,
        Orders.TotalPrice
    FROM 
        Orders
    JOIN 
        Users ON Orders.UserID = Users.UserID
    JOIN 
        OrderItems ON Orders.OrderID = OrderItems.OrderID
    JOIN 
        Menu ON OrderItems.MenuID = Menu.MenuID
    JOIN 
        Chefs ON Menu.ChefID = Chefs.ChefID
    WHERE  
        Orders.OrderStatus = @orderstatus AND Chefs.ChefID = @ChefID 
    GROUP BY 
        users.Fname, users.Lname, users.Phone, users.Address, orders.OrderID, Orders.TotalPrice;
    ";

            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ChefID", Session.Id);
                command.Parameters.AddWithValue("@orderstatus", status);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                PanelTemplate.Visible = false;

                while (reader.Read())
                {
                    Panel newCard = new Panel
                    {
                        Size = PanelTemplate.Size,
                        BackColor = PanelTemplate.BackColor,
                        Tag = reader["orderid"]
                    };

                    foreach (Control control in PanelTemplate.Controls)
                    {
                        Control clonedControl = CloneControl(control);
                        newCard.Controls.Add(clonedControl);
                    }

                    // تخصيص البيانات داخل الكارد
                    Label nameLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_name");
                    if (nameLabel != null) nameLabel.Text = reader["username"].ToString();

                    Label numLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "label4");
                    if (numLabel != null) numLabel.Text = reader["orderid"].ToString();

                    Label phoneLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_phone");
                    if (phoneLabel != null) phoneLabel.Text = reader["Phone"].ToString();

                    Label addressLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_Address");
                    if (addressLabel != null) addressLabel.Text = reader["Address"].ToString();

                    // تفاصيل الأطباق
                    Label dishesLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_order_name");
                    if (dishesLabel != null)
                    {
                        // تقسيم الأطباق التي تم إرجاعها بواسطة STRING_AGG
                        string[] dishNames = reader["DishNames"].ToString().Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        dishesLabel.Text = string.Join("\n", dishNames); // عرض الأطباق
                    }

                    // الكميات
                    Label quantitiesLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_order_quantity");
                    if (quantitiesLabel != null)
                    {
                        string[] quantities = reader["Quantities"].ToString().Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        quantitiesLabel.Text = string.Join("\n", quantities); // عرض الكميات
                    }

                    // الأسعار
                    Label pricesLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_order_price");
                    if (pricesLabel != null)
                    {
                        string[] prices = reader["Prices"].ToString().Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        pricesLabel.Text = string.Join("\n", prices) + " EGP"; // عرض الأسعار
                    }

                    // الإجمالي
                    Label totalPriceLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_total_price");
                    if (totalPriceLabel != null)
                    {
                        totalPriceLabel.Text = $"{reader["TotalPrice"]} EGP";
                    }

                    // الزرار View
                    Button viewButton = newCard.Controls.OfType<Button>().FirstOrDefault(c => c.Name == "btn_View_order");
                    if (viewButton != null)
                    {
                        viewButton.Tag = reader["orderid"]; // تخزين OrderID
                        viewButton.Click += btn_View_order_Click; // ربط بالحدث
                    }

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

        private void LoadOrderDetailsToPanel(int orderId)
        {
            string query = @"
    SELECT 
        users.Fname + ' ' + users.Lname AS username,
        users.Phone,
        users.Address,
        Menu.DishName,
        OrderItems.Quantity,
        OrderItems.Price,
        Orders.TotalPrice
    FROM 
        Orders
    JOIN 
        Users ON Orders.UserID = Users.UserID
    JOIN 
        OrderItems ON Orders.OrderID = OrderItems.OrderID
    JOIN 
        Menu ON OrderItems.MenuID = Menu.MenuID
    WHERE  
        Orders.OrderID = @OrderID;
";

            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderID", orderId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                decimal subtotal = 0; // لحساب subtotal بناءً على العناصر
                int rowIndex = 0; // لاستخدامها مع العناصر المتكررة

                label5.Text = "";
                label30.Text = "";
                label31.Text = "";
                while (reader.Read())
                {
                    // تحديث البيانات الثابتة (التي لا تتغير مثل الاسم، العنوان، الهاتف)
                    if (rowIndex == 0)
                    {
                        label20.Text = orderId.ToString();
                        lbl_client_name.Text = reader["username"].ToString();
                        lbl_clientPhone.Text = reader["Phone"].ToString();
                        label10.Text = reader["Address"].ToString();
                    }

                    // إضافة الأطباق، الكميات، والأسعار
                    string dishName = reader["DishName"].ToString();
                    string quantity = reader["Quantity"].ToString();
                    string price = reader["Price"].ToString();

                    // إضافة القيم للأطباق، الكميات، والأسعار في الـ Labels
                    label5.Text += $"{dishName}\n"; // إضافة أسماء الأطباق
                    label30.Text += $"{quantity}\n"; // إضافة الكميات
                    label31.Text += $"{price} EGP\n"; // إضافة الأسعار

                    // احتساب الـ Subtotal
                    subtotal += Convert.ToDecimal(price) * Convert.ToDecimal(quantity);

                    rowIndex++; // الانتقال إلى السطر التالي
                }

                // حساب الإجمالي والـ Delivery
                decimal delivery = 20;
                decimal total = subtotal + delivery;

                lbl_subtotal.Text = $"{subtotal} EGP";
                lbl_delvery_price.Text = $"{delivery} EGP";
                lbl_total.Text = $"{total} EGP";

                reader.Close();
            }
        }
    
        private void UpdateOrderStatus (string status)
        {
                int orderid = Convert.ToInt32(label20.Text);
                try
                {

                    // كتابة استعلام الـ UPDATE لتحديث حالة الطلب
                    string updateQuery = @"
                            UPDATE Orders
                            SET OrderStatus = @status
                            WHERE OrderID = @OrderID;
                        ";

                    // تنفيذ الاستعلام باستخدام SqlConnection
                    using (SqlConnection connection = new SqlConnection(Connection.connectionString))
                    {
                        SqlCommand command = new SqlCommand(updateQuery, connection);
                        command.Parameters.AddWithValue("@OrderID", orderid); // إضافة معلمة الـ OrderID
                        command.Parameters.AddWithValue("@status", status);

                    connection.Open();
                        int rowsAffected = command.ExecuteNonQuery(); // تنفيذ التحديث
                    if (status == "Pending")
                    {
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Order Accepted");
                        }
                        else
                        {
                            MessageBox.Show("No order found with the specified OrderID.");
                        }
                    }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                flowLayoutPanel1.Controls.Clear();
                CreateOrderCardsFromDatabase("new");
            
        }

        private void btn_pendingorders_Click(object sender, EventArgs e)
        {
            btn_acceptorder.Text = "Done";
            btn_acceptorder.BackColor = Color.Green;
            pnl_order_details.Visible = false;
            lbl_status.Text = "Pending Orders";
            flowLayoutPanel1.Controls.Clear();
            CreateOrderCardsFromDatabase("Pending");

        }

        private void lbl_logout_Click(object sender, EventArgs e)
        {
            Session.Logout();

            login login = new login();
            login.Show();
            this.Hide();
        }

        private void btn_DoneOrders_Click(object sender, EventArgs e)
        {
            lbl_status.Text = "Done Orders";
            btn_acceptorder.Text = "Print Receipt";
            btn_acceptorder.BackColor= Color.FromArgb(204, 82, 48);
            flowLayoutPanel1.Controls.Clear();
            CreateOrderCardsFromDatabase("Done");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string searchQuery = txt_search_order.Text.Trim().ToLower(); // الحصول على النص المدخل
            foreach (Panel card in flowLayoutPanel1.Controls.OfType<Panel>())
            {
                // ابحث عن العنصر المطلوب داخل الكارت
                Label nameLabel = card.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "label4");

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

        private void txt_search_order_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_search_order.Text))
            {
                foreach (Panel card in flowLayoutPanel1.Controls.OfType<Panel>())
                {
                    PanelTemplate.Visible = false;
                    card.Visible = true; // إعادة إظهار جميع الكروت
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Owner_Profile owner_Profile = new Owner_Profile(Session.Id);
            owner_Profile.Show();
            this.Hide();
        }
        private void PrintReceipt()
        {
            // إعداد النصوص
            printContent = "Tabkha Receipt\n";
            printContent += "---------------------------\n";
            printContent += $"Order ID: {label20.Text}\n";
            printContent += $"Client Name: {lbl_client_name.Text}\n";
            printContent += $"Phone: {lbl_clientPhone.Text}\n";
            printContent += $"Address: {label10.Text}\n";
            printContent += "---------------------------\n";
            printContent += "Item         Qty    Price\n";
            printContent += "---------------------------\n";

            string[] items = label5.Text.Split('\n'); // أسماء الأطباق
            string[] quantities = label30.Text.Split('\n'); // الكميات
            string[] prices = label31.Text.Split('\n'); // الأسعار

            for (int i = 0; i < items.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(items[i]))
                {
                    printContent += $"{items[i].PadRight(12)} {quantities[i].PadRight(6)} {prices[i]}\n";
                }
            }

            printContent += "---------------------------\n";
            printContent += $"Subtotal: {lbl_subtotal.Text}\n";
            printContent += $"Delivery: {lbl_delvery_price.Text}\n";
            printContent += $"Total: {lbl_total.Text}\n";
            printContent += "---------------------------\n";
            printContent += "Thank you for using Tabkha!";

            // احسب الطول المطلوب بناءً على النص
            float lineHeight = new Font("Arial", 12).GetHeight(); // ارتفاع السطر
            int totalLines = printContent.Split('\n').Length; // عدد الأسطر
            int pageHeight = (int)(lineHeight * totalLines) + 100; // إضافة هامش علوي وسفلي

            // ضبط حجم الورقة
            PaperSize paperSize = new PaperSize("Custom", 400, pageHeight); // العرض 300 والطول ديناميكي
            printDocument1.DefaultPageSettings.PaperSize = paperSize;

            // عرض مربع معاينة الطباعة
            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDocument1;

            if (previewDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }



        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // إعداد الخطوط
            Font titleFont = new Font("Arial", 16, FontStyle.Bold );
            Font subtitleFont = new Font("Arial", 12, FontStyle.Bold );
            Font contentFont = new Font("Arial", 10);
            Font smallFont = new Font("Arial", 8);
            Brush brush = Brushes.Black;

            // إعداد المواضع
            float x = 50; // الهامش الأفقي
            float y = 50; // الهامش الرأسي
            float lineHeight = contentFont.GetHeight(e.Graphics);

            // رسم العنوان
            e.Graphics.DrawString("TABKHA", titleFont, brush, x + 100, y);
            y += lineHeight + 20;

            // رسم الخط الفاصل
            e.Graphics.DrawLine(Pens.Black, x, y, x + 300, y);
            y += 10;

            // رسم البيانات الأساسية
            e.Graphics.DrawString($"Order ID: {label20.Text}", contentFont, brush, x, y);
            y += lineHeight;
            e.Graphics.DrawString($"Client Name: {lbl_client_name.Text}", contentFont, brush, x, y);
            y += lineHeight;
            e.Graphics.DrawString($"Phone: {lbl_clientPhone.Text}", contentFont, brush, x, y);
            y += lineHeight;
            e.Graphics.DrawString($"Address: {label10.Text}", contentFont, brush, x, y);
            y += lineHeight + 10;

            // رسم الخط الفاصل
            e.Graphics.DrawLine(Pens.Black, x, y, x + 300, y);
            y += 10;

            // عنوان جدول الطلبات
            e.Graphics.DrawString("Item                      Qty               Price", subtitleFont, brush, x, y);
            y += lineHeight + 10;

            // رسم الخط الفاصل
            e.Graphics.DrawLine(Pens.Black, x, y, x + 300, y);
            y += 10;

            // رسم عناصر الطلب
            string[] items = label5.Text.Split('\n');
            string[] quantities = label30.Text.Split('\n');
            string[] prices = label31.Text.Split('\n');

            for (int i = 0; i < items.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(items[i]))
                {
                    e.Graphics.DrawString(items[i], contentFont, brush, x, y);
                    e.Graphics.DrawString(quantities[i], contentFont, brush, x + 150, y);
                    e.Graphics.DrawString(prices[i], contentFont, brush, x + 220, y);
                    y += lineHeight;
                }
            }

            // رسم الخط الفاصل
            y += 10;
            e.Graphics.DrawLine(Pens.Black, x, y, x + 300, y);
            y += 10;

            // رسم المجموعات
            e.Graphics.DrawString($"Subtotal: {lbl_subtotal.Text}", contentFont, brush, x, y);
            y += lineHeight;
            e.Graphics.DrawString($"Delivery: {lbl_delvery_price.Text}", contentFont, brush, x, y);
            y += lineHeight;
            e.Graphics.DrawString($"Total: {lbl_total.Text}", subtitleFont, brush, x, y);
            y += lineHeight + 10;

            // رسم الخط الفاصل
            e.Graphics.DrawLine(Pens.Black, x, y, x + 300, y);
            y += 10;

            // رسالة الشكر
            e.Graphics.DrawString("    THANK YOU FOR USING TABKHA!", contentFont, brush, x + 20, y);
            y += lineHeight + 20;

          
        }
    
    }
}
