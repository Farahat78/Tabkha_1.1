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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            user_home user_Home = new user_home();
            user_Home.Show();
            this.Hide();
        }

        private void label29_Click(object sender, EventArgs e)
        {
            Customer_Profile customer_Profile = new Customer_Profile(Session.Id);
            customer_Profile.Show();
            this.Hide();
        }
    }
}
