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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Gpnl_choices.Hide();
            pnl_show.Show();
        }

        private void img_show_Click(object sender, EventArgs e)
        {
            Gpnl_choices.Show();
            pnl_show.Hide();
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
            Manage_Profile view = new Manage_Profile();
            view.edit_invisible();
            LoadFormIntoPanel(view);     
            //pnl_order.Hide();
            //pnl_edit.Show();
            //btn_editEmail.Hide();
            //btn_editBdate.Hide();
            //btn_editPnumber.Hide();
            //btn_editName.Hide();
            lbl_data.Text = "Profile";

        }

        private void btn_manageProfile_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new Manage_Profile());
            //pnl_order.Hide();
            //pnl_edit.Show();
            // btn_editEmail.Show();
            //btn_editBdate.Show();
            //btn_editPnumber.Show();
            //btn_editName.Show();
            lbl_data.Text = "Manage Your Profile";
        }

        private void btn_viewOrdersData_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new View_order_details());
            lbl_data.Text = "Your Order data";
            //pnl_order.Show();
        }
    }
}
