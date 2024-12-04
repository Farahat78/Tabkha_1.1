using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabkha_1._1
{
    public partial class ManageChefForm : Form
    {
        public ManageChefForm()
        {
            InitializeComponent();
        }

        private DataTable chefsTable;

        private void ManageChefsForm_Load(object sender, EventArgs e)
        {
            chefsTable = new DataTable();
            chefsTable.Columns.Add("Chef ID", typeof(int));
            chefsTable.Columns.Add("Name", typeof(string));
            chefsTable.Columns.Add("Email", typeof(string));
            chefsTable.Columns.Add("Phone Number", typeof(int));
            chefsTable.Columns.Add("Password", typeof(int));
            chefsTable.Columns.Add("Specialty", typeof(string));

            dgv_chefs.DataSource = chefsTable;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AddEditChef detailsForm = new AddEditChef();
            detailsForm.change_add();
            if (detailsForm.ShowDialog() == DialogResult.OK)
            {
                dgv_chefs.Rows.Add(dgv_chefs.Rows.Count + 1, detailsForm.ChefName, detailsForm.Email, detailsForm.Phone, detailsForm.Specialty, detailsForm.Password);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dgv_chefs.CurrentRow != null)
            {
                AddEditChef detailsForm = new AddEditChef
                {
                    ChefName = dgv_chefs.CurrentRow.Cells["nme"].Value.ToString(),
                    Email = dgv_chefs.CurrentRow.Cells["email"].Value.ToString(),
                    Phone = dgv_chefs.CurrentRow.Cells["number"].Value.ToString(),
                    Password = dgv_chefs.CurrentRow.Cells["Password"].Value.ToString(),
                    Specialty = dgv_chefs.CurrentRow.Cells["specialty"].Value.ToString()
                };
                detailsForm.passwod_ReadOnly();
                detailsForm.change_edit();
                if (detailsForm.ShowDialog() == DialogResult.OK)
                {
                    dgv_chefs.CurrentRow.Cells["nme"].Value = detailsForm.ChefName;
                    dgv_chefs.CurrentRow.Cells["email"].Value = detailsForm.Email;
                    dgv_chefs.CurrentRow.Cells["number"].Value = detailsForm.Phone;
                    dgv_chefs.CurrentRow.Cells["specialty"].Value = detailsForm.Specialty;
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgv_chefs.CurrentRow != null)
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
                    dgv_chefs.Rows.Remove(dgv_chefs.CurrentRow);
                }
            }
            else
            {
                MessageBox.Show("Please select a chef to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_chefs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ManageChefForm_Load(object sender, EventArgs e)
        {
            //display();
        }
    }
}
