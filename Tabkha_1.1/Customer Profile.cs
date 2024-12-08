﻿using System;
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
        private bool isSidebarExpanded = true;

        public Customer_Profile()
        {
            InitializeComponent();
        }

        private void ChangeColor(Button btn, Button btn2)
        {
            btn.BackColor = Color.White;
            btn2.BackColor = Color.Transparent;
        }

        public void LoadFormIntoPanel(Form Form)
        {
            Gpnl_general.Controls.Clear();
            Form.TopLevel = false;
            Form.Dock = DockStyle.Fill;
            Gpnl_general.Controls.Add(Form);
            Form.Show();
        }

        public void hideSome()
        {
            btn_orders.Visible = false;
            
        }

        private void img_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void img_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_manageProfile_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new Manage_Profile());
            lbl_data.Text = "Manage Your Profile";
        }

        private void btn_viewOrdersData_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new View_order_details());
            lbl_data.Text = "Your Order data";
        }

        private void Customer_Profile_Load(object sender, EventArgs e)
        {
            lbl_data.Text = "Profile";
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            ChangeColor(btn_view, btn_orders);
            lbl_data.Text = "Profile";
            Manage_Profile veiw = new Manage_Profile();
            veiw.readOnly();
            LoadFormIntoPanel(veiw);
        }

        private void btn_orders_Click(object sender, EventArgs e)
        {
            ChangeColor(btn_orders, btn_view);
            lbl_data.Text = "Previous Orders";
            LoadFormIntoPanel(new uploadnew());
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
                pnl_sidebar.Width = 150;
                Gpnl_general.Location = new Point(pnl_sidebar.Width, Gpnl_general.Location.Y);
                Gpnl_general.Width = this.Width - pnl_sidebar.Width;
            }
            else
            {
                pnl_sidebar.Width = 50;
                Gpnl_general.Location = new Point(pnl_sidebar.Width, Gpnl_general.Location.Y);
                Gpnl_general.Width = this.Width - pnl_sidebar.Width;
            }
        }

        private void btn_out_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
