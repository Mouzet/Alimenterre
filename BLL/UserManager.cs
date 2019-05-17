using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserManager
    {
        public static User getInfos(int idUser)
        {

        }
        public static List<User> GetUsers(int IdCanton, int IdProduit, int IdCategorieProduit, int IdCompetence, int IdActivite)
        {
            List<User> result = new List<User>();



            List<User> listUser = UserDB.GetUsers(Competence, Activite);

            // Ici on controle que la personne soit dans le bon canton
            if (Canton != null)
            {
                int IdCanton = UserDB.GetIdCanton(Canton);

                List<int> listLocalisation = LocalisationDB.GetLocByIdCanton(IdCanton);
                foreach (User user in listUser)
                {
                    foreach (int id in listLocalisation)
                    {
                        if (user.IdLocalisation == id)
                            result.Add(user);
                    }
                }

                // Retire les users deja selectionnés de la liste
                foreach (User user in result)
                {
                    listUser.Remove(user);
                }
            }

            // Ici on controle que la produise la bonne categorie de ressources
            if (Produit != null)
            {
                int IdProduit = UserDB.GetIdProduit(Produit);

                List<int> listUserProd = UserProduitDB.GetUserId(IdProduit);
                foreach (int idUser in listUserProd)
                {
                    foreach (User user in listUser)
                    {
                        if (user.IdUser == idUser)
                            result.Add(user);
                    }
                }

                // Retire les users deja selectionnés de la liste
                foreach (User user in result)
                {
                    listUser.Remove(user);
                }
            }
            else if (CategorieProduit != null)
            {
                int IdCategorieProduit = UserDB.GetIdCategorie(CategorieProduit);

                List<int> listUserProd = UserProduitDB.GetUserIdFromCat(IdCategorieProduit);
                foreach (int idUser in listUserProd)
                {
                    foreach (User user in listUser)
                    {
                        if (user.IdUser == idUser)
                            result.Add(user);
                    }
                }
            }

            return result;
        }
        
        public static int GetIdCanton(string NomCanton)
        {
            int idCanton = UserDB.GetIdCanton(NomCanton);

            return idCanton;
        }

        public static int GetIdProduit(string NomProduit)
        {
            int idProduit = UserDB.GetIdProduit(NomProduit);

            return idProduit;
        }

        public static int GetIdCategorie(string NomCategorie)
        {
            int idCategorie = UserDB.GetIdCategorie(NomCategorie);

            return idCategorie;
        }
    }
}
