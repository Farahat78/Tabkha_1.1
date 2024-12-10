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
    public partial class orders : Form
    {
        private string connectionString = Connection.connectionString;

        private void LoadOrders()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // جلب الطلبات مع معلومات المستخدمين
                    string query = @"
                        SELECT O.OrderID, O.TotalPrice, O.OrderStatus,
                               U.Fname, U.Lname, U.Phone, U.Address
                        FROM Orders O
                        INNER JOIN Users U ON O.UserID = U.UserID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable ordersTable = new DataTable();
                    adapter.Fill(ordersTable);

                    // عرض الطلبات ديناميكيًا
                    foreach (DataRow row in ordersTable.Rows)
                    {
                        Button orderButton = new Button
                        {
                            Text = $"Order #{row["OrderID"]} - {row["TotalPrice"]} EGP",
                            Tag = row,
                            Width = 300,
                            Height = 50,
                            Margin = new Padding(5)
                        };

                        orderButton.Click += (sender, e) =>
                        {
                            ShowOrderDetails((DataRow)((Button)sender).Tag);
                        };

                       
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ShowOrderDetails(DataRow orderData)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // تعبئة تفاصيل الطلب
                    label4.Text = orderData["OrderID"].ToString();
                    //lbl_client_name.Text = $"{orderData["Fname"]} {orderData["Lname"]}";
                    lbl_name.Text = $"{orderData["Fname"]} {orderData["Lname"]}";
                    lbl_clientPhone.Text = orderData["Phone"].ToString();
                    //lbl_phone.Text = orderData["Phone"].ToString();
                    //label10.Text = $"{orderData["Address"]}";
                    lbl_Address.Text = $"{orderData["Address"]}";
                    lbl_total_price.Text = $"{orderData["TotalPrice"]} EGP";
                   

                    // جلب بيانات OrderItems المرتبطة
                    string orderItemsQuery = @"
                        SELECT OI.OrderItemID, OI.Quantity, OI.Price, M.ItemName
                        FROM OrderItems OI
                        INNER JOIN Menu M ON OI.MenuID = M.MenuID
                        WHERE OI.OrderID = @OrderID";

                    SqlCommand cmd = new SqlCommand(orderItemsQuery, conn);
                    cmd.Parameters.AddWithValue("@OrderID", orderData["OrderID"]);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable orderItemsTable = new DataTable();
                    adapter.Fill(orderItemsTable);

                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        public orders()
        {
            InitializeComponent();
            LoadOrders();
        }

        private void btn_View_order_Click(object sender, EventArgs e)
        {
            pnl_order_details.Visible = true;
            
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
            MessageBox.Show("Order Accepted");

        }
    }
}
