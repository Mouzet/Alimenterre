using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class LocalisationDB
    {
        public static List<int> GetLocByIdCanton(int IdCanton)
        {
            List<int> result = null;

            string connectionString = ConfigurationManager.ConnectionStrings["AlimenterreDB"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id FROM Localisations WHERE Canton_Id =  @IdCanton";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdCanton", IdCanton);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (result == null)
                                result = new List<int>();

                            result.Add((int)dr["Id"]);
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
