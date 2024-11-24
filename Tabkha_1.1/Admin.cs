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
    public partial class Admin : Form
    {
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
            ChangeColor(btn_dashboard, btn_chefs, btn_delivery, btn_users);
        }

        private void btn_chefs_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new ManageChefForm());
            ChangeColor(btn_chefs,btn_dashboard,btn_delivery,btn_users);
        }

        private void btn_users_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new ManageUser());
            ChangeColor(btn_users, btn_dashboard, btn_delivery, btn_chefs);
        }

        private void btn_delivery_Click(object sender, EventArgs e)
        {
            ChangeColor(btn_delivery, btn_dashboard, btn_chefs, btn_users);
        }
    }
}
