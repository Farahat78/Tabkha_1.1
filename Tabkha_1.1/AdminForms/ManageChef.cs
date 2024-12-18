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
using Tabkha_1._1.Class;

namespace Tabkha_1._1
{
    public partial class ManageChefForm : Form
    {
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
            using (SqlConnection conn = Connection.Instance.GetConnection())
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
                using (SqlConnection conn = Connection.Instance.GetConnection())
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

                            if (conn.State == System.Data.ConnectionState.Closed)
                            {
                                conn.Open();
                            }
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

                    using (SqlConnection conn = Connection.Instance.GetConnection())
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

                                if (conn.State == System.Data.ConnectionState.Closed)
                                {
                                    conn.Open();
                                }
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
                    "Are you sure you want to delete this Chef and all related data?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = Connection.Instance.GetConnection())
                    {
                        if (conn.State == System.Data.ConnectionState.Closed)
                        {
                            conn.Open();
                        }

                        using (SqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                int rowIndex = dgv_chefs.SelectedCells[0].RowIndex;
                                DataGridViewRow row = dgv_chefs.Rows[rowIndex];
                                int id = Convert.ToInt32(row.Cells["ChefID"].Value);

                                // Delete related data
                                string deleteMenu = "DELETE FROM Menu WHERE ChefID = @Id";
                                string deleteChef = "DELETE FROM Chefs WHERE ChefID = @Id";

                                // Delete related records
                                ExecuteDeleteCommand(deleteMenu, id, conn, transaction);

                                // Delete the chef
                                ExecuteDeleteCommand(deleteChef, id, conn, transaction);

                                // Commit transaction
                                transaction.Commit();

                                MessageBox.Show("Chef and related data deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Reload data
                                LoadData();
                            }
                            catch (SqlException sqlEx)
                            {
                                transaction.Rollback();
                                MessageBox.Show($"Database error: {sqlEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a Chef to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExecuteDeleteCommand(string query, int id, SqlConnection conn, SqlTransaction transaction)
        {
            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                cmd.ExecuteNonQuery();
            }
        }


        private void dgv_chefs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ManageChefForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void customTextBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = customTextBox1.Text.Trim();

            string query = @"
        SELECT 
            [ChefID],
            [Fname] + ' ' + [Lname] AS [Chef Name], 
            [Email] AS [Email],
            [Password] AS [Password],
            [Phone] AS [Phone Number],
            [Rname] AS [Restaurant Name]
        FROM [tabkha1].[dbo].[Chefs]
        WHERE [Fname] LIKE @Search OR [Lname] LIKE @Search 
              OR ([Fname] + ' ' + [Lname]) LIKE @Search";

            using (SqlConnection conn = Connection.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add the search parameter
                    cmd.Parameters.AddWithValue("@Search", $"%{searchText}%");

                    try
                    {
                        if (conn.State == System.Data.ConnectionState.Closed)
                        {
                            conn.Open();
                        }
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind filtered data to the DataGridView
                        dgv_chefs.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
