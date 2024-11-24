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
            txt_confirmPassword.Text = "";
            txt_phone.Text = "";
            txt_lname.Text = "";
            txtbox_address.Text = "";
            txtbox_city.Text = "";
            txtbox_fname.Text="";
            

        }

        private void btn_signUp_Click(object sender, EventArgs e)
        {
            if (txt_confirmPassword.Text != txt_password.Text)
            {
                MessageBox.Show("Review password");
            }
            else if (txt_email.Text == ""
           || txt_password.Text == ""
           || txt_confirmPassword.Text == ""
           || txt_phone.Text == ""
           || txt_lname.Text == ""
           || txtbox_address.Text == ""
           || txtbox_city.Text == ""
           || txtbox_fname.Text == "")
            { MessageBox.Show("Required Fields Empty"); }
            else
            {
                user_home user_Home = new user_home();
                user_Home.Show();
                this.Hide();
            }
        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_signIn_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Hide();
        }
    }
}
