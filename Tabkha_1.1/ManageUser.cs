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

        private DataTable usersTable;

        private void ManageChefsForm_Load(object sender, EventArgs e)
        {
            usersTable = new DataTable();
            usersTable.Columns.Add("User ID", typeof(int));
            usersTable.Columns.Add("Name", typeof(string));
            usersTable.Columns.Add("Email", typeof(string));

            dgv_users.DataSource = usersTable;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AddEditUser detailsForm = new AddEditUser();
            if (detailsForm.ShowDialog() == DialogResult.OK)
            {
                dgv_users.Rows.Add(dgv_users.Rows.Count + 1, detailsForm.UserName, detailsForm.Email);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dgv_users.CurrentRow != null)
            {
                AddEditChef detailsForm = new AddEditChef
                {
                    ChefName = dgv_users.CurrentRow.Cells["nme"].Value.ToString(),
                    Specialty = dgv_users.CurrentRow.Cells["email"].Value.ToString()
                };

                if (detailsForm.ShowDialog() == DialogResult.OK)
                {
                    dgv_users.CurrentRow.Cells["nme"].Value = detailsForm.ChefName;
                    dgv_users.CurrentRow.Cells["email"].Value = detailsForm.Specialty;
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgv_users.CurrentRow != null)
            {
                // Confirm deletion
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this chef?",
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
                MessageBox.Show("Please select a chef to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
