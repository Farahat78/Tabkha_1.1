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
    public partial class user_home : Form
    {
        public user_home()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void img_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void check_breakfast_CheckedChanged(object sender, EventArgs e)
        {
            if (check_breakfast.Checked || check_bakery.Checked || check_lunch.Checked || check_dessert.Checked || check_drinks.Checked)
            {
                btn_apply.Enabled = true;
                btn_apply.BackColor = Color.FromArgb(204, 82, 48); // اللون الأساسي للزر
            }
            else
            {
                btn_apply.Enabled = false;
                btn_apply.BackColor = Color.Gray;
            }
        }

        private void user_home_Load(object sender, EventArgs e)
        {
            btn_apply.Enabled = false;
            btn_apply.BackColor = Color.Gray;
        }
    }
}
