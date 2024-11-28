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
    public partial class Owner_Profile : Form
    {
        public Owner_Profile()
        {
            InitializeComponent();
        }

        private void ChangeColor(Button btn, Button btn2, Button btn3, Button btn4 , Button btn5)
        {
            btn.BackColor = Color.FromArgb(236, 172, 124);
            btn2.BackColor = Color.FromArgb(204, 82, 48);
            btn3.BackColor = Color.FromArgb(204, 82, 48);
            btn4.BackColor = Color.FromArgb(204, 82, 48);
            btn5.BackColor = Color.FromArgb(204, 82, 48);

            btn.ForeColor = Color.Black;
            btn2.ForeColor = Color.White;
            btn3.ForeColor = Color.White;
            btn4.ForeColor = Color.White;
            btn5.ForeColor = Color.White;
        }
        private void img_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void img_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_appitizer_Click(object sender, EventArgs e)
        {
            ChangeColor(btn_appitizer, btn_dessert, btn_mainCourse, btn_salad, btn_soup);
        }

        private void btn_mainCourse_Click(object sender, EventArgs e)
        {
            ChangeColor(btn_mainCourse, btn_appitizer, btn_dessert, btn_salad, btn_soup);
        }

        private void btn_soup_Click(object sender, EventArgs e)
        {
            ChangeColor(btn_soup,btn_appitizer, btn_dessert, btn_mainCourse, btn_salad);
        }

        private void btn_salad_Click(object sender, EventArgs e)
        {
            ChangeColor(btn_salad,btn_appitizer, btn_dessert, btn_mainCourse, btn_soup);
        }

        private void btn_dessert_Click(object sender, EventArgs e)
        {
            ChangeColor(btn_dessert,btn_appitizer, btn_mainCourse, btn_salad, btn_soup);
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Manage_Profile manage_Profile = new Manage_Profile();
            manage_Profile.Show();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            uploadnew uploadnew = new uploadnew();
            uploadnew.Show();
            this.Hide();
        }
    }
}
