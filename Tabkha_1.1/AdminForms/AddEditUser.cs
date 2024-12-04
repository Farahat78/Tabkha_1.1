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
        public string Nme 
        {
            get => txt_name.Text;
            set => txt_name.Text = value;
        }
        public string Fname { get; set; }

        public string Lname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_name.Text) && !string.IsNullOrWhiteSpace(txt_email.Text) && !string.IsNullOrWhiteSpace(txt_password.Text) && !string.IsNullOrWhiteSpace(txt_phone.Text))
            {
                string[] Name = txt_name.Text.Split(' ');
                Fname = Name.Length > 0 ? Name[0] : ""; ;
                Lname = Name.Length > 1 ? string.Join(" ", Name.Skip(1)) : "";
                Email = txt_email.Text;
                Password = txt_password.Text;
                Phone = txt_phone.Text;
                Address = txt_address.Text;
                City = txt_city.Text;

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
            txt_name.Text = Nme;
            txt_email.Text = Email;
            txt_address.Text = Address;
            txt_phone.Text = Phone;
            txt_password.Text = Password;
            txt_city.Text = City;
        }
        public void passwod_ReadOnly()
        {
            txt_password.ReadOnly = !txt_password.ReadOnly;
        }
        public void change_edit()
        {
            btn_save.Text = "Edit";
        }
        public void change_add()
        {
            btn_save.Text = "Add";
        }
        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
