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
    public partial class Delivery : Form
    {
        //private void Display()
        //{
        //    string query = @"SELECT [ChefID], ,,[Password] AS [Password],[Phone] AS [Phone Number]
        //              ,[Rname] AS [Restaurant Name]
        //          FROM [tabkha1].[dbo].[Chefs]";
        //    using (SqlConnection conn = new SqlConnection(Connection.connectionString))
        //    {
        //        SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
        //        DataTable dataTable = new DataTable();
        //        dataAdapter.Fill(dataTable);
                
        //    }
        //}
        public Delivery()
        {
            InitializeComponent();
        }

        private void img_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void img_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_View_order_Click(object sender, EventArgs e)
        {
            pnl_order_details.Visible = true;
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
