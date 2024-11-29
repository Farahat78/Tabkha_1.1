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
    public partial class AddEditChef : Form
    {
        public AddEditChef()
        {
            InitializeComponent();
        }

        private void img_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void img_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public string ChefName
        {
            get => txt_name.Text;
            set => txt_name.Text = value;
        }

        public string Specialty
        {
            get => txt_specialty.Text;
            set => txt_specialty.Text = value;
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
            get => txt_number.Text;
            set => txt_number.Text = value;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_name.Text) && !string.IsNullOrWhiteSpace(txt_specialty.Text))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void change_edit()
        {
            btn_save.Text = "Edit";
        }
        public void change_add()
        {
            btn_save.Text = "Add";
        }

        public void passwod_ReadOnly()
        {
            txt_password.ReadOnly = !txt_password.ReadOnly;
        }

        private void txt_specialty_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_number_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
