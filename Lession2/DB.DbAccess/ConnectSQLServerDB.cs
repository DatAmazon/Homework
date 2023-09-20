using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.DbAccess
{
    public class ConnectSQLServerDB
    {
        public static SqlConnection GetSqlConnection()
        {
            string connectionString = "Data Source=DESKTOP-S3UOKJU\\SQLEXPRESS;Initial Catalog=Lession2DB;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
    }
}
