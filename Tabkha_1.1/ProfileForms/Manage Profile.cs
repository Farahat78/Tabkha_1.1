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
    public partial class Manage_Profile : Form
    {
        public string SName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Manage_Profile()
        {
            InitializeComponent();
        }

        public void readOnly()
        {
            txtbox_password.ReadOnly = true;
            txtbox_email.ReadOnly = true;
            txtbox_name.ReadOnly = true;
            txtbox_Pnumber.ReadOnly = true;
            btn_edit_img.Visible = false;
            btn_save.Visible = false;
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            txtbox_password.ReadOnly = false;
            txtbox_email.ReadOnly = false;
            txtbox_name.ReadOnly = false;
            txtbox_Pnumber.ReadOnly = false;
            btn_edit_img.Visible = true;
            btn_save.Visible = true;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            readOnly();
        }

        private void Manage_Profile_Load(object sender, EventArgs e)
        {
            txtbox_email.Text = Email;
            txtbox_name.Text = Name;
            txtbox_password.Text = Password;
        }
    }
}
