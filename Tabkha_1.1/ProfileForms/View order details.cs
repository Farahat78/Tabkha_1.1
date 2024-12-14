using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tabkha_1._1.Class;

namespace Tabkha_1._1
{
    public partial class View_order_details : Form
    {
        private string printContent;
        private decimal Delivery_Price = 20; 
        public View_order_details()
        {
            InitializeComponent();
            
        }

        private void CreateOrderCardsFromDatabase()
        {
            string query = @"
                SELECT 
                    users.UserID,
                    users.Fname + ' ' + users.Lname AS username,
                    users.Phone,
                    users.Address,
                    orders.OrderID AS orderid,
                    orders.OrderStatus,
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
                    Users.UserID = @UserID
                GROUP BY 
                    users.UserID, users.Fname, users.Lname, users.Phone, users.Address, 
                    orders.OrderID, orders.OrderStatus, Orders.TotalPrice , Orders.CreatedAt
                ORDER BY 
                    orders.CreatedAt DESC;";

            using (SqlConnection connection = new SqlConnection(Connection.connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", Session.Id);

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

                    // تخصيص حالة الطلب 
                    Label orderStatusLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "label8");
                    if (orderStatusLabel != null)
                    {
                        string orderStatus = reader["OrderStatus"].ToString();
                        orderStatusLabel.Text = orderStatus;

                        // تغيير اللون بناءً على الحالة
                        switch (orderStatus)
                        {
                            case "new":
                                orderStatusLabel.BackColor = Color.Red;     
                                orderStatusLabel.ForeColor = Color.White;   
                                break;

                            case "pending":
                                orderStatusLabel.BackColor = Color.Orange;   
                                orderStatusLabel.ForeColor = Color.Black;   
                                break;

                            case "Done":
                                orderStatusLabel.BackColor = Color.Green;  
                                orderStatusLabel.ForeColor = Color.White;  
                                break;

                            default:
                                orderStatusLabel.BackColor = Color.Gray;    
                                orderStatusLabel.ForeColor = Color.White;
                                break;
                        }
                    }

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

                    // تعديل الكود عند إنشاء الكاردات
                    Button viewButton = newCard.Controls.OfType<Button>().FirstOrDefault(c => c.Name == "btn_Print_reciept");
                    if (viewButton != null)
                    {
                        viewButton.Tag = newCard; // تخزين الكارد في الـ Tag الخاص بالزر
                        viewButton.Click += btn_Print_reciept_Click; // ربط الحدث
                        ApplyElipse(viewButton);
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

        private void btn_Print_reciept_Click(object sender, EventArgs e)
        {

            // نحصل على الزر الذي تم الضغط عليه
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                // نجلب الـ Panel المرتبطة بهذا الزر
                Panel selectedCard = clickedButton.Tag as Panel;

                if (selectedCard != null)
                {
                    // نجمع القيم المطلوبة من الحقول داخل الكارد
                    var itemLabels = selectedCard.Controls.OfType<Label>().Where(c => c.Name.StartsWith("lbl_order_name")).ToList();
                    var quantityLabels = selectedCard.Controls.OfType<Label>().Where(c => c.Name.StartsWith("lbl_order_quantity")).ToList();
                    var priceLabels = selectedCard.Controls.OfType<Label>().Where(c => c.Name.StartsWith("lbl_order_price")).ToList();

                    // التحقق من أن القيم الثلاث (اسم العنصر، الكمية، السعر) متطابقة في العدد
                    if (itemLabels.Count == quantityLabels.Count && quantityLabels.Count == priceLabels.Count)
                    {
                        // إعادة تعيين الحقول في الفاتورة لعرض العناصر
                        lbl_order_name.Text = "";
                        lbl_order_quantity.Text = "";
                        lbl_order_price.Text = "";

                        for (int i = 0; i < itemLabels.Count; i++)
                        {
                            // جمع كل عنصر وخصائصه لعرضها في الفاتورة
                            lbl_order_name.Text += itemLabels[i].Text + "\n";
                            lbl_order_quantity.Text += quantityLabels[i].Text + "\n";
                            lbl_order_price.Text += priceLabels[i].Text + "\n";
                        }

                        // طباعة الفاتورة
                        PrintReceipt();
                    }
                }
            }
            else
            {
                // رسالة خطأ إذا لم يتم الضغط على الزر بشكل صحيح
                MessageBox.Show("حدث خطأ أثناء محاولة الطباعة.");
            }
        }

        private void btn_previousOrder_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = true;
            CreateOrderCardsFromDatabase();
        }

        private void PrintReceipt()
        {
            // إعداد النصوص
            printContent = "Tabkha Receipt\n";
            printContent += "---------------------------\n";
            printContent += $"Order ID: {label4.Text}\n";
            printContent += $"Client Name: {lbl_name.Text}\n";
            printContent += $"Phone: {lbl_phone.Text}\n";
            printContent += $"Address: {lbl_Address.Text}\n";
            printContent += "---------------------------\n";
            printContent += "Item         Qty    Price\n";
            printContent += "---------------------------\n";

            string[] items = label5.Text.Split('\n'); // أسماء الأطباق
            string[] quantities = lbl_order_quantity.Text.Split('\n'); // الكميات
            string[] prices = lbl_order_price.Text.Split('\n'); // الأسعار

            decimal subtotal = 0; // تعريف المجموع الجزئي

            for (int i = 0; i < items.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(items[i]))
                {
                    // التأكد من القيم الصحيحة
                    decimal price = decimal.TryParse(prices[i], out decimal parsedPrice) ? parsedPrice : 0;
                    int quantity = int.TryParse(quantities[i], out int parsedQuantity) ? parsedQuantity : 0;

                    decimal itemTotal = price * quantity; // حساب المجموع للعنصر الحالي
                    subtotal += itemTotal; // جمع المجموع الجزئي

                    // إضافة البيانات إلى الإيصال
                    printContent += $"{items[i].PadRight(12)} {quantities[i].PadRight(6)} {prices[i]}\n";
                }
            }

            // عرض المجموع الجزئي
            printContent += "---------------------------\n";
            printContent += $"Subtotal: {subtotal:F2} EGP\n"; // عرض المجموع بصيغة عشرية
            printContent += $"Delivery: {Delivery_Price} EGP\n";
            printContent += $"Total: {(subtotal + Delivery_Price):F2} EGP\n";
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

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // إعداد الخطوط
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font subtitleFont = new Font("Arial", 12, FontStyle.Bold);
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
            e.Graphics.DrawString($"Order ID: {label4.Text}", contentFont, brush, x, y);
            y += lineHeight;
            e.Graphics.DrawString($"Client Name: {lbl_name.Text}", contentFont, brush, x, y);
            y += lineHeight;
            e.Graphics.DrawString($"Phone: {lbl_phone.Text}", contentFont, brush, x, y);
            y += lineHeight;
            e.Graphics.DrawString($"Address: {lbl_Address.Text}", contentFont, brush, x, y);
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
            string[] items = lbl_order_name.Text.Split('\n'); // أسماء الأطباق
            string[] quantities = lbl_order_quantity.Text.Split('\n'); // الكميات
            string[] prices = lbl_order_price.Text.Split('\n'); // الأسعار

            decimal subtotal = 0; // تعريف المجموع الجزئي

            for (int i = 0; i < items.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(items[i]))
                {
                    // التأكد من القيم الصحيحة
                    decimal price = decimal.TryParse(prices[i], out decimal parsedPrice) ? parsedPrice : 0;
                    int quantity = int.TryParse(quantities[i], out int parsedQuantity) ? parsedQuantity : 0;

                    decimal itemTotal = price * quantity; // حساب المجموع للعنصر الحالي
                    subtotal += itemTotal; // جمع المجموع الجزئي

                    // إضافة البيانات إلى الإيصال
                    e.Graphics.DrawString(items[i], contentFont, brush, x, y);
                    e.Graphics.DrawString(quantity.ToString(), contentFont, brush, x + 150, y);
                    e.Graphics.DrawString(price.ToString("F2"), contentFont, brush, x + 220, y);
                    y += lineHeight;
                }
            }

            // رسم الخط الفاصل
            y += 10;
            e.Graphics.DrawLine(Pens.Black, x, y, x + 300, y);
            y += 10;

            // رسم المجموعات
            e.Graphics.DrawString($"Subtotal: {subtotal:F2} EGP", contentFont, brush, x, y); // عرض المجموع الجزئي
            y += lineHeight;
            e.Graphics.DrawString($"Delivery: {Delivery_Price:F2} EGP", contentFont, brush, x, y);
            y += lineHeight;
            e.Graphics.DrawString($"Total: {(subtotal + Delivery_Price):F2} EGP", subtitleFont, brush, x, y);
            y += lineHeight + 10;

            // رسم الخط الفاصل
            e.Graphics.DrawLine(Pens.Black, x, y, x + 300, y);
            y += 10;

            // رسالة الشكر
            e.Graphics.DrawString("    THANK YOU FOR USING TABKHA!", contentFont, brush, x + 20, y);
            y += lineHeight + 20;
        }

        private void ApplyElipse(Button button)
        {

            Guna2Elipse elipse = new Guna2Elipse();
            elipse.TargetControl = button;            
            elipse.BorderRadius = 30; 


        }

        private string GetLatestOrderStatus(int userId)
        {
            string orderStatus = string.Empty;

            // استعلام لاسترجاع آخر طلب بناءً على ID المستخدم
            string query = "SELECT TOP 1 OrderStatus FROM Orders WHERE UserID = @UserID ORDER BY OrderID DESC";

            using (SqlConnection conn = new SqlConnection(Connection.connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", userId);

                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    orderStatus = result.ToString();
                }
            }

            return orderStatus;
           
        }

        private void UpdateOrderProgress(string orderStatus)
        {
            // تحديث النص في الـ Label بناءً على حالة الطلب
            switch (orderStatus)
            {
                case "New":
                    lbl_OrderStatus.Text = "Your order is new and will be processed soon.";
                    progressBar1.Value = 25; // تحديث قيمة الـ ProgressBar
                    lbl_OrderStatus.ForeColor = Color.Blue; // تغيير لون النص إلى الأزرق
                    progressBar1.ForeColor = Color.Blue; // تغيير لون الـ ProgressBar إلى الأزرق
                    break;

                case "Pending":
                    lbl_OrderStatus.Text = "Your order is being prepared.";
                    progressBar1.Value = 50; // تحديث قيمة الـ ProgressBar
                    lbl_OrderStatus.ForeColor = Color.Orange; // تغيير لون النص إلى البرتقالي
                    progressBar1.ForeColor = Color.Orange; // تغيير لون الـ ProgressBar إلى البرتقالي
                    break;

                case "Done":
                    lbl_OrderStatus.Text = "Your order is ready and on its way!";
                    progressBar1.Value = 100; // تحديث قيمة الـ ProgressBar
                    lbl_OrderStatus.ForeColor = Color.Green; // تغيير لون النص إلى الأخضر
                    progressBar1.ForeColor = Color.Green; // تغيير لون الـ ProgressBar إلى الأخضر
                    break;

                default:
                    lbl_OrderStatus.Text = "Unknown order status.";
                    progressBar1.Value = 0; // إعادة ضبط الـ ProgressBar
                    lbl_OrderStatus.ForeColor = Color.Red; // تغيير لون النص إلى الأحمر
                    progressBar1.ForeColor = Color.Red; // تغيير لون الـ ProgressBar إلى الأحمر
                    break;
            }
        }

        private void View_order_details_Load(object sender, EventArgs e)
        {
            string orderstatus =GetLatestOrderStatus(Session.Id);
            UpdateOrderProgress(orderstatus);
        }
    }
}
