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
