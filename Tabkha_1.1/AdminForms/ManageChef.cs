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
        string connectionString = "Data Source=Hossam;Initial Catalog=tabkha1;Integrated Security=True;Encrypt=False";

        private void LoadData()
        {
            string query = @"
                SELECT 
                       [ChefID]
                      ,[Fname] +' '+ [Lname] AS [Chef Name]
                      ,[Email] AS [Email]
                      ,[Password] AS [Password]
                      ,[Phone] AS [Phone Number]
                      ,[Rname] AS [Restaurant Name]
                  FROM [tabkha1].[dbo].[Chefs]";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgv_chefs.DataSource = dataTable;
            }
        }
        public ManageChefForm()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            using (var form = new AddEditChef())
            {
                form.change_add();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        string query = "INSERT INTO Chefs (Fname,Lname,Password,Email,Phone,Rname) VALUES (@Fname, @Lname, @Password, @Email, @Phone, @Rname)";
                        using (var cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Fname", form.Fname);
                            cmd.Parameters.AddWithValue("@Lname", form.Lname);
                            cmd.Parameters.AddWithValue("@Password", form.Password);
                            cmd.Parameters.AddWithValue("@Email", form.Email);
                            cmd.Parameters.AddWithValue("@Phone", form.Phone);
                            cmd.Parameters.AddWithValue("@Rname", form.Rname);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        LoadData();
                    }
                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dgv_chefs.CurrentRow != null)
            {
                int rowIndex = dgv_chefs.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgv_chefs.Rows[rowIndex];

                int id = Convert.ToInt32(row.Cells["ChefID"].Value);

                using (var form = new AddEditChef())
                {
                    form.passwod_ReadOnly();
                    form.change_edit();
                    form.ChefName = row.Cells["Chef Name"].Value.ToString();
                    form.Password = row.Cells["Password"].Value.ToString();
                    form.Rname = row.Cells["Restaurant Name"].Value.ToString();
                    form.Phone = row.Cells["Phone Number"].Value.ToString();
                    form.Email = row.Cells["Email"].Value.ToString();

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            string query = "UPDATE Chefs SET Fname = @Fname, Lname = @Lname, Email = @Email, Phone = @Phone, Password = @Password, Rname = @Rname WHERE ChefID = @Id";
                            using (var cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@Fname", form.Fname);
                                cmd.Parameters.AddWithValue("@Lname", form.Lname);
                                cmd.Parameters.AddWithValue("@Email", form.Email);
                                cmd.Parameters.AddWithValue("@Phone", form.Phone);
                                cmd.Parameters.AddWithValue("@Password", form.Password);
                                cmd.Parameters.AddWithValue("@Rname", form.Rname);
                                cmd.Parameters.AddWithValue("@Id", id);

                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                            LoadData();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a cell to edit a user.");
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgv_chefs.CurrentRow != null)
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
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        int rowIndex = dgv_chefs.SelectedCells[0].RowIndex;
                        DataGridViewRow row = dgv_chefs.Rows[rowIndex];

                        int id = Convert.ToInt32(row.Cells["ChefID"].Value);
                        string query = "DELETE FROM Chefs WHERE ChefID = @Id";
                        using (var cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", id);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a User to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_chefs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ManageChefForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
