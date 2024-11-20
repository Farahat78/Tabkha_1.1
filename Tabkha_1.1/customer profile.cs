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
    public partial class customer_profile : Form
    {
        public customer_profile()
        {
            InitializeComponent();
        }

        private void pnl_profile_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnl_profile_MouseClick(object sender, MouseEventArgs e)
        {
            pnl_edit.BackColor= Color.White;
            pnl_viewOrder.BackColor= Color.White;
            pnl_signOut.BackColor= Color.White;
            pnl_profile.BackColor= Color.FromArgb(204, 82, 48); 

            pnl_profile.ForeColor = Color.White;
            pnl_viewOrder.ForeColor = Color.Black;
            pnl_edit.ForeColor = Color.Black;
            pnl_signOut.ForeColor = Color.Black;

        }

        private void pnl_viewOrder_MouseClick(object sender, MouseEventArgs e)
        {
            pnl_edit.BackColor = Color.White;
            pnl_profile.BackColor = Color.White;
            pnl_signOut.BackColor = Color.White;
            pnl_viewOrder.BackColor = Color.FromArgb(204, 82, 48); 


            pnl_profile.ForeColor = Color. Black;
            pnl_viewOrder.ForeColor = Color. White;
            pnl_edit.ForeColor = Color.Black;
            pnl_signOut.ForeColor = Color.Black;
        }

        private void pnl_edit_MouseClick(object sender, MouseEventArgs e)
        {
            pnl_edit.BackColor = Color.FromArgb(204, 82, 48); 
            pnl_profile.BackColor = Color.White;
            pnl_signOut.BackColor = Color.White;
            pnl_viewOrder.BackColor = Color.White; 

            pnl_profile.ForeColor = Color.Black;
            pnl_viewOrder.ForeColor = Color.Black;
            pnl_edit.ForeColor = Color.White;
            pnl_signOut.ForeColor = Color.Black;
        }

        private void lbl_profile_Click(object sender, EventArgs e)
        {
            pnl_edit.BackColor = Color.White;
            pnl_viewOrder.BackColor = Color.White;
            pnl_signOut.BackColor = Color.White;
            pnl_profile.BackColor = Color.FromArgb(204, 82, 48);

            pnl_profile.ForeColor = Color.White;
            pnl_viewOrder.ForeColor = Color.Black;
            pnl_edit.ForeColor = Color.Black;
            pnl_signOut.ForeColor = Color.Black;

        }

      

        private void lbl_viewOrder_Click(object sender, EventArgs e)
        {
            pnl_edit.BackColor = Color.White;
            pnl_profile.BackColor = Color.White;
            pnl_signOut.BackColor = Color.White;
            pnl_viewOrder.BackColor = Color.FromArgb(204, 82, 48);


            pnl_profile.ForeColor = Color.Black;
            pnl_viewOrder.ForeColor = Color.White;
            pnl_edit.ForeColor = Color.Black;
            pnl_signOut.ForeColor = Color.Black;
        }

        private void lbl_edit_Click(object sender, EventArgs e)
        {

            pnl_edit.BackColor = Color.FromArgb(204, 82, 48);
            pnl_profile.BackColor = Color.White;
            pnl_signOut.BackColor = Color.White;
            pnl_viewOrder.BackColor = Color.White;

            pnl_profile.ForeColor = Color.Black;
            pnl_viewOrder.ForeColor = Color.Black;
            pnl_edit.ForeColor = Color.White;
            pnl_signOut.ForeColor = Color.Black;
        }

        private void img_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void img_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void img_maximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
