using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabkha_1._1
{
    public partial class user_home : Form
    {
        public user_home()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void img_maximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void img_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_order_Click(object sender, EventArgs e)
        {
            Product_details product = new Product_details();
            product.Show();

        }

        private void img_product_Click(object sender, EventArgs e)
        {
            Product_details product = new Product_details();
            product.Show();
        }

        private void btn_placeorder_Click(object sender, EventArgs e)
        {
            place_order order = new place_order();
            order.Show();
        }
    }
}
