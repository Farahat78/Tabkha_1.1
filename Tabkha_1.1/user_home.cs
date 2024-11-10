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

        private void check_breakfast_CheckedChanged(object sender, EventArgs e)
        {
            if (check_breakfast.Checked || check_bakery.Checked || check_lunch.Checked || check_dessert.Checked || check_drinks.Checked)
            {
                btn_apply.Enabled = true;
                btn_apply.BackColor = Color.FromArgb(204, 82, 48); // اللون الأساسي للزر
            }
            else
            {
                btn_apply.Enabled = false;
                btn_apply.BackColor = Color.Gray;
            }
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
        }

        private void user_home_Load(object sender, EventArgs e)
        {
            btn_apply.Enabled = false;
            btn_apply.BackColor = Color.Gray;
        }

        private void txt_search_Enter(object sender, EventArgs e)
        {
            txt_search.Text = "";
            txt_search.ForeColor = Color.Black;
        }

        private void txt_search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_search.Text))
            {
                txt_search.Text = "Search Restaurants";
                txt_search.ForeColor = Color.Gray;
            }
        }
    }
}
