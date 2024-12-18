using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tabkha_1._1.Class;

namespace Tabkha_1._1
{
    public partial class Admin : Form
    {
       
        private bool isSidebarExpanded = true;

        public Admin()
        {
            InitializeComponent();
        }
        private void ChangeColor(Button btn,Button btn2, Button btn3, Button btn4)
        {
            btn.BackColor = Color.White;
            btn2.BackColor = Color.Transparent;
            btn3.BackColor = Color.Transparent;
            btn4.BackColor = Color.Transparent;
        }
        private void LoadFormIntoPanel(Form form)
        {
            guna2GradientPanel3.Controls.Clear();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            guna2GradientPanel3.Controls.Add(form);
            form.Show();
        }


        private void img_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void img_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            ChangeColor(btn_dashboard, btn_chefs, btn_users, btn_out);
            guna2GradientPanel3.Controls.Clear();
        }

        private void btn_chefs_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new ManageChefForm());
            ChangeColor(btn_chefs,btn_dashboard,btn_users, btn_out);
        }

        private void btn_users_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new ManageUser());
            ChangeColor(btn_users, btn_dashboard, btn_chefs, btn_out);
        }

        private void x(object sender, PaintEventArgs e)
        {
            
        }

        private void btn_out_Click(object sender, EventArgs e)
        {
            Session.Logout();

            login l = new login();
            l.Show();
            this.Close();
        }

        private void btn_toggleSideBar_Click(object sender, EventArgs e)
        {
            isSidebarExpanded = !isSidebarExpanded;
            AdjustMainPanel();
        }
        private void AdjustMainPanel()
        {
            if (isSidebarExpanded)
            {
                guna2GradientPanel2.Width = 210;
                guna2GradientPanel3.Location = new Point(guna2GradientPanel2.Width, guna2GradientPanel3.Location.Y);
                guna2GradientPanel3.Width = this.Width - guna2GradientPanel2.Width;
            }
            else
            {
                guna2GradientPanel2.Width = 50; 
                guna2GradientPanel3.Location = new Point(guna2GradientPanel2.Width, guna2GradientPanel3.Location.Y);
                guna2GradientPanel3.Width = this.Width - guna2GradientPanel2.Width;
            }
        }

        private void lbl_account_Click(object sender, EventArgs e)
        {
            Customer_Profile adminProfile = new Customer_Profile(Session.Id);
            adminProfile.orders = false;
            adminProfile.Show();
            this.Hide();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            lbl_account.Text = Session.Name;
            guna2CirclePictureBox1.Image = !string.IsNullOrEmpty(Session.pic)
            ? Image.FromFile(Session.pic)
            : Properties.Resources.Max_R_Headshot__1_;
        }
    }
}
