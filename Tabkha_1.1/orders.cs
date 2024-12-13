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
    
        public orders()
        {
            InitializeComponent();
            CreateOrderCardsFromDatabase("new");
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

        }

        private void btn_neworders_Click(object sender, EventArgs e)
        {
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
                command.Parameters.AddWithValue("@ChefID",Session.Id);
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
                    if (dishesLabel != null) dishesLabel.Text = reader["DishNames"].ToString();

                    // الكميات
                    Label quantitiesLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_quantities");
                    if (quantitiesLabel != null) quantitiesLabel.Text = reader["Quantities"].ToString();

                    // الأسعار
                    Label pricesLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_order_price");
                    if (pricesLabel != null) pricesLabel.Text = reader["Prices"].ToString();

                    // الإجمالي
                    Label totalPriceLabel = newCard.Controls.OfType<Label>().FirstOrDefault(c => c.Name == "lbl_total_price");
                    if (totalPriceLabel != null) totalPriceLabel.Text = $"{reader["TotalPrice"]}";

                    flowLayoutPanel1.Controls.Add(newCard);
                }

                reader.Close();
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

        private void btn_pendingorders_Click(object sender, EventArgs e)
        {
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
    }
}
