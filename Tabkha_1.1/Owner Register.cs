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
    public partial class Owner_Register : Form
    {
        public Owner_Register()
        {
            InitializeComponent();
        }

        private void btn_signUp_Click(object sender, EventArgs e)
        {
            if (txt_confirmPassword.Text!=txt_password.Text)
            {
                MessageBox.Show("Review password");
            }
            else if (txt_fname.Text=="" 
                ||txt_password.Text == "" 
                ||txt_email.Text==""
                || txt_confirmPassword.Text==""
                || txtbox_phoneNumber.Text==""
                ||txtbox_bio.Text==""
                || txtbox_businesssName.Text=="")
            { MessageBox.Show("Required Fields Empty"); }
            else
            {
                user_home user_Home = new user_home();
            user_Home.Show();
            this.Hide();
            }
        }

        private void btn_clear_Click_1(object sender, EventArgs e)
        {
            txt_fname.Text = "";
            txtbox_lname.Text = "";
            txt_password.Text = "";
            txt_email.Text = "";
            txt_confirmPassword.Text = "";
            txtbox_phoneNumber.Text = "";
            txtbox_bio.Text = "";
            txtbox_businesssName.Text = "";

        }

        private void img_minimize_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void img_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void register_card_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_signIn_Click(object sender, EventArgs e)
        {
            login login  = new login();
            login.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt_confirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbox_businesssName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_disc_Click(object sender, EventArgs e)
        {

        }
    }
}
