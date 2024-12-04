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
    public partial class ManageUser : Form
    {
        public ManageUser()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AddEditUser detailsForm = new AddEditUser();
            detailsForm.change_add();
            if (detailsForm.ShowDialog() == DialogResult.OK)
            {
                dgv_users.Rows.Add(dgv_users.Rows.Count + 1, detailsForm.UserName, detailsForm.Email, detailsForm.Phone, detailsForm.Address, detailsForm.Password); 
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dgv_users.CurrentRow != null)
            {
                    form.passwod_ReadOnly();
                    form.change_edit();
                    form.Nme = row.Cells["Name"].Value.ToString();
                    form.Password = row.Cells["Password"].Value.ToString();
                    form.Address = row.Cells["Address"].Value.ToString();
                    form.City = row.Cells["City"].Value.ToString();
                    form.Phone = row.Cells["Phone Number"].Value.ToString();
                    form.Email = row.Cells["Email"].Value.ToString();
                    
                    using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    UserName = dgv_users.CurrentRow.Cells["nme"].Value.ToString(),
                    Email = dgv_users.CurrentRow.Cells["email"].Value.ToString(),
                    Phone = dgv_users.CurrentRow.Cells["number"].Value.ToString(),
                    Address = dgv_users.CurrentRow.Cells["address"].Value.ToString(),
                    Password = dgv_users.CurrentRow.Cells["Password"].Value.ToString(),
                };
                detailsForm.passwod_ReadOnly();
                detailsForm.change_edit();
                if (detailsForm.ShowDialog() == DialogResult.OK)
                {
                    dgv_users.CurrentRow.Cells["nme"].Value = detailsForm.UserName;
                    dgv_users.CurrentRow.Cells["email"].Value = detailsForm.Email;
                    dgv_users.CurrentRow.Cells["number"].Value = detailsForm.Phone;
                    dgv_users.CurrentRow.Cells["address"].Value = detailsForm.Address;
                }
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgv_users.CurrentRow != null)
            {
                // Confirm deletion
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this User?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    // Remove the selected row
                    dgv_users.Rows.Remove(dgv_users.CurrentRow);
                }
            }
            else
            {
                MessageBox.Show("Please select a User to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ManageUser_Load(object sender, EventArgs e)
        {
        }
    }
}
