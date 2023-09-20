using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DB.DbAccess
{
    public class SqlDbHelper
    {
        static string connectionString = "Data Source=DESKTOP-S3UOKJU\\SQLEXPRESS;Initial Catalog=Lession2DB;Integrated Security=True";
        public static List<Product> GetProducts()
        {
            var list = new List<Product>();

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "ProcGetListPro";
                    try
                    {
                        cnn.Open();
                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            if (rd.HasRows)
                            {
                                while (rd.Read())
                                {
                                    list.Add(new Product
                                    {
                                        ProductID = Convert.ToInt32(rd["ProductID"].ToString()),
                                        Name = rd["Name"] != DBNull.Value ? rd["Name"].ToString() : string.Empty,
                                        Price = Convert.ToDouble(rd["Price"]),
                                        Quantity = Convert.ToInt32(rd["Quantity"].ToString())
                                    });
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            return list;
        }

        public static Product GetProductById(int id)
        {
            Product pro = null;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "ProcGetProByID";
                    cmd.Parameters.AddWithValue("@productId", id);
                    try
                    {
                        cnn.Open();
                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            if (rd.HasRows)
                            {
                                while (rd.Read())
                                {
                                    pro = new Product
                                    {
                                        ProductID = Convert.ToInt32(rd["ProductID"]),
                                        Name = rd["Name"] != DBNull.Value ? rd["Name"].ToString() : string.Empty,
                                        Price = Convert.ToDouble(rd["Price"]),
                                        Quantity = Convert.ToInt32(rd["Quantity"])
                                    };
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            return pro;
        }

        public static void CreateProduct(string name, float price, int quantity)
        {

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "ProcCreateProduct";
                    cmd.Parameters.AddWithValue("@proName", name);
                    cmd.Parameters.AddWithValue("@quatity", quantity);
                    cmd.Parameters.AddWithValue("@price", price);
                    try
                    {
                        cnn.Open();
                        int check = cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }

        }
        public static void EditProduct(int id, string name, float price, int quantity)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "ProcEditProById";
                    cmd.Parameters.AddWithValue("@productId", id);
                    cmd.Parameters.AddWithValue("@proName", name);
                    cmd.Parameters.AddWithValue("@price", quantity);
                    cmd.Parameters.AddWithValue("@quatity", price);
                    try
                    {
                        cnn.Open();
                        int check = cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        public static void DeleteProduct(int id)
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "ProcDeleteById";
                    cmd.Parameters.AddWithValue("@productId", id);
                    try
                    {
                        cnn.Open();
                        int check = cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        public static List<Product> SearchProByName(string search)
        {
            List<Product> products = new List<Product>();
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "searchProByName";
                    cmd.Parameters.AddWithValue("@proName", search);
                    try
                    {
                        cnn.Open();
                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            if (rd.HasRows)
                            {
                                while (rd.Read())
                                {
                                    products.Add(new Product
                                    {
                                        ProductID = Convert.ToInt32(rd["ProductID"].ToString()),
                                        Name = rd["Name"] != DBNull.Value ? rd["Name"].ToString() : string.Empty,
                                        Price = Convert.ToDouble(rd["Price"]),
                                        Quantity = Convert.ToInt32(rd["Quantity"].ToString())
                                    });
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            return products;

        }
    }

}

