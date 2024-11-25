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
    public partial class AddEditUser : Form
    {
        public AddEditUser()
        {
            InitializeComponent();
        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {

        }

        private void img_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void img_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public string UserName
        {
            get => txt_name.Text;
            set => txt_name.Text = value;
        }

        public string Email
        {
            get => txt_email.Text;
            set => txt_email.Text = value;
        }

        public string Password
        {
            get => txt_password.Text;
            set => txt_password.Text = value;
        }

        public string Phone
        {
            get => txt_phone.Text;
            set => txt_phone.Text = value;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_name.Text) && !string.IsNullOrWhiteSpace(txt_email.Text) && !string.IsNullOrWhiteSpace(txt_password.Text) && !string.IsNullOrWhiteSpace(txt_phone.Text))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_save_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_name.Text) && !string.IsNullOrWhiteSpace(txt_email.Text) && !string.IsNullOrWhiteSpace(txt_password.Text) && !string.IsNullOrWhiteSpace(txt_phone.Text))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddEditUser_Load(object sender, EventArgs e)
        {
            
        }
        public void passwod_ReadOnly(bool x)
        {
            txt_password.ReadOnly = !txt_password.ReadOnly;
        }
        public void change_edit(bool x)
        {
            btn_save.Text = "Edit";
        }
        public void change_add(bool x)
        {
            btn_save.Text = "Add";
        }
        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
