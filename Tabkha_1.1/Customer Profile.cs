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
            pnl_show.Hide();
            btn_edit2.Hide();
            btn_edit3.Hide();
            btn_edit4.Hide();
            btn_editName.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pnl_hide.Hide();
            Gpnl_choices.Hide();
            pnl_show.Show();
        }

        private void img_show_Click(object sender, EventArgs e)
        {
            pnl_hide.Show();
            Gpnl_choices.Show();
            pnl_show.Hide();
        }

        private void rbtn_profile_Click(object sender, EventArgs e)
        {
            btn_edit2.Hide();
            btn_edit3.Hide();
            btn_edit4.Hide();
            btn_editName.Hide();
            lbl_data.Text = "Profile";
        }

        private void rbtn_manageProfile_Click(object sender, EventArgs e)
        {
            btn_edit2.Show();
            btn_edit3.Show();
            btn_edit4.Show();
            btn_editName.Show();
            lbl_data.Text = "Manage Your Profile";
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
    }
}
