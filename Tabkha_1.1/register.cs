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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void login_card_Paint(object sender, PaintEventArgs e)
        {

        }

        private void img_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void img_close_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_email.Text = "";
            txt_password.Text = "";
            txt_phone.Text = "";
            txt_username.Text = "U";
            radio_btn_female.Checked = false;
            radio_btn_male.Checked = false;

        }

        private void btn_signUp_Click(object sender, EventArgs e)
        {
            user_home user_Home = new user_home();
            user_Home.Show();
            this.Hide();
        }
    }
}
