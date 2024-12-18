using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabkha_1._1.Class
{
    public class Connection
    {
        private static Connection _instance; 
        private static readonly object _lock = new object(); 
        private SqlConnection _sqlConnection;

        private Connection()
        {
           
            _sqlConnection = new SqlConnection("Data Source=GODZILA\\SQLEXPRESS;Initial Catalog=tabkha1;Integrated Security=True;Encrypt=False");
        }

       
        public static Connection Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Connection();
                        }
                    }
                }
                return _instance;
            }
        }


        public SqlConnection GetConnection()
        {
            if (_sqlConnection.ConnectionString == string.Empty)
            {
                _sqlConnection.ConnectionString = "Data Source=GODZILA\\SQLEXPRESS;Initial Catalog=tabkha1;Integrated Security=True;Encrypt=False";
            }
            return _sqlConnection;
        }

    }
}
