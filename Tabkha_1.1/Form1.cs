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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_apptizer_Click(object sender, EventArgs e)
        {
            btn_apptizer.BackColor = Color.FromArgb(204, 82, 48);
            btndessert.BackColor = Color.FromArgb(236, 172, 124);
            btn_main.BackColor = Color.FromArgb(236, 172, 124);
            btn_soup.BackColor = Color.FromArgb(236, 172, 124);
            btn_salad.BackColor = Color.FromArgb(236, 172, 124);
        }

        private void btndessert_Click(object sender, EventArgs e)
        {
            btn_apptizer.BackColor = Color.FromArgb(236, 172, 124);
            btndessert.BackColor = Color.FromArgb(204, 82, 48);
            btn_main.BackColor = Color.FromArgb(236, 172, 124);
            btn_soup.BackColor = Color.FromArgb(236, 172, 124);
            btn_salad.BackColor = Color.FromArgb(236, 172, 124);
        }

        private void btn_main_Click(object sender, EventArgs e)
        {
            btn_apptizer.BackColor = Color.FromArgb(236, 172, 124);
            btndessert.BackColor = Color.FromArgb(236, 172, 124);
            btn_main.BackColor = Color.FromArgb(204, 82, 48);
            btn_soup.BackColor = Color.FromArgb(236, 172, 124);
            btn_salad.BackColor = Color.FromArgb(236, 172, 124);
        }

        private void btn_soup_Click(object sender, EventArgs e)
        {
            btn_apptizer.BackColor = Color.FromArgb(236, 172, 124);
            btndessert.BackColor = Color.FromArgb(236, 172, 124);
            btn_main.BackColor = Color.FromArgb(236, 172, 124);
            btn_soup.BackColor = Color.FromArgb(204, 82, 48);
            btn_salad.BackColor = Color.FromArgb(236, 172, 124);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_salad_Click(object sender, EventArgs e)
        {
            btn_apptizer.BackColor = Color.FromArgb(236, 172, 124);
            btndessert.BackColor = Color.FromArgb(236, 172, 124);
            btn_main.BackColor = Color.FromArgb(236, 172, 124);
            btn_soup.BackColor = Color.FromArgb(236, 172, 124);
            btn_salad.BackColor = Color.FromArgb(204, 82, 48);

        }
    }
}
