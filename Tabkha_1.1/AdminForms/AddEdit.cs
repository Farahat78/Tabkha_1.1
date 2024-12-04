using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
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
        public string Fname { get; set; }

        public string Lname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Rname { get; set; }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_name.Text) && !string.IsNullOrWhiteSpace(txt_Rname.Text))
            {
                string[] Name = txt_name.Text.Split(' ');
                Fname = Name.Length > 0 ? Name[0] : ""; ;
                Lname = Name.Length > 1 ? string.Join(" ", Name.Skip(1)) : "";
                Email = txt_email.Text;
                Password = txt_password.Text;
                Phone = txt_number.Text;
                Rname = txt_Rname.Text;

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

        private void AddEditChef_Load(object sender, EventArgs e)
        {
            txt_name.Text = ChefName;
            txt_email.Text = Email;
            txt_Rname.Text = Rname;
            txt_number.Text = Phone;
            txt_password.Text = Password;
        }
    }
}
