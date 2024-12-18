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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace Tabkha_1._1
{
    public partial class ManageUser : Form
    {
        public ManageUser()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            string query = @"
                SELECT 
                    [UserID],
                    [Fname] + ' ' + [Lname] AS [Name], 
                    [Email] AS [Email],
                    [Phone] AS [Phone Number],
                    [Address] AS [Address],
                    [City] AS [City],
                    [Password] AS [Password]
                FROM [tabkha1].[dbo].[Users]";
            using (SqlConnection conn = Connection.Instance.GetConnection())
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgv_users.DataSource = dataTable;
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            using (var form = new AddEditUser())
            {
                form.change_add();
                using (SqlConnection conn = Connection.Instance.GetConnection())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        string query = "INSERT INTO Users (Fname,Lname,Password,Email,Phone,Address,City) VALUES (@Fname, @Lname, @Password, @Email, @Phone, @Address, @City)";
                        using (var cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Fname", form.Fname);
                            cmd.Parameters.AddWithValue("@Lname", form.Lname);
                            cmd.Parameters.AddWithValue("@Password", form.Password);
                            cmd.Parameters.AddWithValue("@Email", form.Email);
                            cmd.Parameters.AddWithValue("@Phone", form.Phone);
                            cmd.Parameters.AddWithValue("@Address", form.Address);
                            cmd.Parameters.AddWithValue("@City", form.City);

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
            if(dgv_users.CurrentRow != null)
            {
                int rowIndex = dgv_users.SelectedCells[0].RowIndex;
                DataGridViewRow row = dgv_users.Rows[rowIndex];

                int id = Convert.ToInt32(row.Cells["UserID"].Value);

                using (var form = new AddEditUser())
                {
                    form.passwod_ReadOnly();
                    form.change_edit();
                    form.Nme = row.Cells["Name"].Value.ToString();
                    form.Password = row.Cells["Password"].Value.ToString();
                    form.Address = row.Cells["Address"].Value.ToString();
                    form.City = row.Cells["City"].Value.ToString();
                    form.Phone = row.Cells["Phone Number"].Value.ToString();
                    form.Email = row.Cells["Email"].Value.ToString();
                    
                    using (SqlConnection conn = Connection.Instance.GetConnection())
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            string query = "UPDATE Users SET Fname = @Fname, Lname = @Lname, Email = @Email, Phone = @Phone, Password = @Password, Address = @Address, City = @City WHERE UserID = @Id";
                            using (var cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@Fname", form.Fname);
                                cmd.Parameters.AddWithValue("@Lname", form.Lname);
                                cmd.Parameters.AddWithValue("@Email", form.Email);
                                cmd.Parameters.AddWithValue("@Phone", form.Phone);
                                cmd.Parameters.AddWithValue("@Password", form.Password);
                                cmd.Parameters.AddWithValue("@Address", form.Address);
                                cmd.Parameters.AddWithValue("@City", form.City);
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
            if (dgv_users.CurrentRow != null)
            {
                // Confirm deletion
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this User and all related data?",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = Connection.Instance.GetConnection())
                    {
                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }

                        using (SqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                int rowIndex = dgv_users.SelectedCells[0].RowIndex;
                                DataGridViewRow row = dgv_users.Rows[rowIndex];
                                int userId = Convert.ToInt32(row.Cells["UserID"].Value);

                                // Delete related data
                                string deleteCart = "DELETE FROM Cart WHERE UserID = @Id";
                                string deleteOrderItems = "DELETE FROM OrderItems WHERE OrderID IN (SELECT OrderID FROM Orders WHERE UserID = @Id)";
                                string deleteOrders = "DELETE FROM Orders WHERE UserID = @Id";
                                string deleteReviews = "DELETE FROM Reviews WHERE UserID = @Id";
                                string deleteUser = "DELETE FROM Users WHERE UserID = @Id";

                                // Execute deletion queries
                                ExecuteDeleteCommand(deleteCart, userId, conn, transaction);
                                ExecuteDeleteCommand(deleteOrderItems, userId, conn, transaction);
                                ExecuteDeleteCommand(deleteOrders, userId, conn, transaction);
                                ExecuteDeleteCommand(deleteReviews, userId, conn, transaction);

                                // Finally, delete the user
                                ExecuteDeleteCommand(deleteUser, userId, conn, transaction);

                                // Commit transaction
                                transaction.Commit();

                                MessageBox.Show("User and related data deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                MessageBox.Show("Please select a User to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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




        private void ManageUser_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            // Get the search text
            string searchText = txt_search.Text.Trim();

            // SQL query with LIKE for searching FName, LName, or both
            string query = @"
        SELECT 
            [UserID],
            [Fname] + ' ' + [Lname] AS [Name], 
            [Email] AS [Email],
            [Phone] AS [Phone Number],
            [Address] AS [Address],
            [City] AS [City],
            [Password] AS [Password]
        FROM [tabkha1].[dbo].[Users]
        WHERE [Fname] LIKE @Search OR [Lname] LIKE @Search 
              OR ([Fname] + ' ' + [Lname]) LIKE @Search";

            using (SqlConnection conn = Connection.Instance.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Add parameter for search
                    cmd.Parameters.AddWithValue("@Search", $"%{searchText}%");

                    try
                    {
                        if (conn.State == System.Data.ConnectionState.Closed)
                        {
                            conn.Open();
                        }
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind the filtered data to the DataGridView
                        dgv_users.DataSource = dt;
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
