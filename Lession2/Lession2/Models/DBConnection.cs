using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace Lession2.Models
{
    public class DBConnection
    {
        string strCon;
        public DBConnection()
        {
            strCon = ConfigurationManager.ConnectionStrings["Lession2DBConect"].ConnectionString;
        }
        
        public SqlConnection GetConnection()
        {
            return new SqlConnection(strCon);
        }

    }
}