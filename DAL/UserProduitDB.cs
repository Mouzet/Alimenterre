using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class UserProduitDB
    {
        public static List<int> GetUserId(int IdProduit)
        {
            List<int> result = null;

            string connectionString = ConfigurationManager.ConnectionStrings["AlimenterreDB"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT User_Id FROM UserProduit WHERE Produit_Id =  @IdProduit";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdProduit", IdProduit);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (result == null)
                                result = new List<int>();

                            result.Add((int)dr["User_Id"]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;

        }
    }
}
