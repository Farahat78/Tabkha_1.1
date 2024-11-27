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
    public partial class Customer_Profile: Form
    {
        public Customer_Profile()
        {
            InitializeComponent();
        }
        public void LoadFormIntoPanel(Form Form)
        {
            pnl_show.Controls.Clear();
            Form.TopLevel = false;
            Form.Dock = DockStyle.Fill;
            pnl_show.Controls.Add(Form);
            Form.Show();
        }

        private void img_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void img_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_logOut_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void btn_viewProfile_Click(object sender, EventArgs e)
        {
            lbl_data.Text = "Profile";
        }

        private void btn_manageProfile_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new Manage_Profile());
            lbl_data.Text = "Manage Your Profile";
        }

        private void btn_viewOrdersData_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new View_order_details());
        }
    }
}
