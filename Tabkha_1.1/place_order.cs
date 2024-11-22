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
    public partial class place_order : Form
    {

        public place_order()
        {
            InitializeComponent();
        }

        private void txt_fname_MouseClick(object sender, MouseEventArgs e)
        {
            txt_fname.Text = null;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            TextBox[] textBoxes = { txt_cardnum, txt_expiry, txt_cvv };

            foreach (TextBox txt in textBoxes)
            {
                txt.ReadOnly = true;
                txt.Text = null;
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            TextBox[] textBoxes = { txt_cardnum, txt_expiry, txt_cvv };
            foreach (TextBox txt in textBoxes)
            {
                txt.ReadOnly = false;
              
            }

        }

        private void img_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void img_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void img_logo_Click(object sender, EventArgs e)
        {

        }
    }
}
