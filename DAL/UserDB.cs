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
        public static User getInfos(int idUser)
        {
            

            string connectionString = ConfigurationManager.ConnectionStrings["AlimenterreDB"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM USERS WHERE Id = @idUser";

                    SqlCommand command = new SqlCommand(query, cn);
                    command.Parameters.AddWithValue("@Id", idUser);
                    cn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();

                        User user = new User();
                        user.IdUser = (int)reader["Id"];
                        user.Nom = (string)reader["Nom"];
                        user.Prenom = (string)reader["Prenom"];
                        user.Societe = (string)reader["Societe"];
                        user.Adresse = (string)reader["Adresse"];
                        user.Telephone = (string)reader["Telephone"];
                        user.Mail = (string)reader["Mail"];
                        user.Description = (string)reader["Description"];
                        user.IdCompetence = (int)reader["Competence_Id"];
                        user.IdActivite = (int)reader["Activite_Id"];
                        user.IdLocalisation = (int)reader["Localisation_Id"];
                        user.IdCategoryUser = (int)reader["CategoryUser_Id"];
                        return user;


                    }
                    }
                }
            catch {
            }
            return null;

        }
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