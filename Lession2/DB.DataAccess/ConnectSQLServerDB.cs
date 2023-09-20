using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DB.DataAccess
{
    public class ConnectSQLServerDB
    {
        public static SqlConnection GetSqlConnection()
        {
            var connectionString = "Data Source=DESKTOP-S3UOKJU\\SQLEXPRESS;Initial Catalog=Lession2DB;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            if(conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
    }
}
