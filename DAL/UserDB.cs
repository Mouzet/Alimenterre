using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDB
    {
        // Requête permettant de retrouver un user selon les critères choisis
        public static List<User> GetUsers(int IdCompetence, int IdActivite)
        {
            List<User> result = null;

            string connectionString = ConfigurationManager.ConnectionStrings["AlimenterreDB"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {          
                    string query = "SELECT * FROM Users WHERE Id = Id ";

                    if (IdCompetence != 0)
                        query += "AND Competence_Id = @IdCompetence ";

                    if (IdActivite != 0)
                        query += "AND Activite_Id = @IdActivite";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@IdCompetence", IdCompetence);
                    cmd.Parameters.AddWithValue("@IdActivite", IdActivite);

                    cn.Open();

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