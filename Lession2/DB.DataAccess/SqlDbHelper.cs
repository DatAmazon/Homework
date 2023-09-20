using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.DataAccess
{
    public static class SqlDbHelper
    {
        public static List<Product> GetProducts()
        {
            var list = new List<Product>();
            try
            {
                using (SqlConnection cnn = ConnectSQLServerDB.GetSqlConnection())
                {
                    using (SqlCommand cmd = cnn.CreateCommand())
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = "sp_tblUser_searchAccount";
                        cnn.Open();
                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            list.Add(new Product
                            {
                                ProductID = Convert.ToInt32(rd["ProductID"].ToString()),
                                Name = rd["Name"] != DBNull.Value ? rd["Name"].ToString() : string.Empty,
                                Price = Convert.ToDouble(rd["Price"]),
                                Quantity = Convert.ToInt32(rd["ProductID"].ToString())
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return list;
        }
    }
}


//public List<Product> GetProducts()
//{
//    var list = new List<Product>();
//    try
//    {
//        var connection = ConnectSQLServerDB.GetSqlConnection();
//        var command = new SqlCommand("ProcGetListPro", connection);
//        command.CommandType = System.Data.CommandType.StoredProcedure;
//    }
//    catch (Exception)
//    {

//        throw;
//    }
//}
