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
            catch
            {

            }
            return null;

        }
        // Requête permettant de retrouver un user selon les critères choisis
        public static List<User> GetUsers(string Competence, string Activite)
        {
            List<User> result = null;
            int IdCompetence = 0;
            int IdActivite = 0;

            string connectionString = ConfigurationManager.ConnectionStrings["AlimenterreDB"].ConnectionString;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {          
                    string query = "SELECT * FROM Users WHERE Id = Id ";

                    if (Competence != null)
                    {
                        IdCompetence = UserDB.GetIdCompetence(Competence);
                        query += "AND Competence_Id = @IdCompetence ";
                    }
                        

                    if (Activite != null)
                    {
                        IdActivite = UserDB.GetIdActivite(Activite);
                        query += "AND Activite_Id = @IdActivite";
                    }
                        
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

        public static int GetIdCanton(string NomCanton)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AlimenterreDB"].ConnectionString;
            int result;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id FROM Cantons WHERE NomCanton = @Nom ";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@Nom", NomCanton);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        result = (int)dr["Id"];
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        public static int GetIdProduit(string NomProduit)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AlimenterreDB"].ConnectionString;
            int result;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id FROM Produits WHERE NomProduit = @Nom ";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@Nom", NomProduit);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        result = (int)dr["Id"];
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        public static int GetIdCategorie(string NomCategorie)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AlimenterreDB"].ConnectionString;
            int result;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id FROM ProduitCategories WHERE NomCategorie = @Nom ";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@Nom", NomCategorie);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        result = (int)dr["Id"];
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        public static int GetIdCompetence(string NomCompetence)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AlimenterreDB"].ConnectionString;
            int result;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id FROM Competences WHERE NomCompetence = @Nom ";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@Nom", NomCompetence);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        result = (int)dr["Id"];
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        public static int GetIdActivite(string NomActivite)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AlimenterreDB"].ConnectionString;
            int result;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id FROM Competences WHERE NomCompetence = @Nom ";

                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@Nom", NomActivite);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        result = (int)dr["Id"];
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