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

        private void LoadFormIntoPanel(Form form)
        {
            guna2ShadowPanel1.Controls.Clear();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            guna2ShadowPanel1.Controls.Add(form);
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

        private void btn_chefs_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new ManageChef());
        }

        private void btn_users_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new login());
        }
    }
}
