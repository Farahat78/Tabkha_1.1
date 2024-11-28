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
    }
}
