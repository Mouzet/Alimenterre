using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserManager
    {
        public static User GetInfos(int idUser)
        {
            return UserDB.GetInfos(idUser);
        }
        public static List<User> GetUsers(int IdCanton, int IdProduit, int IdCategorieProduit, int IdCompetence, int IdActivite)
        {
            List<User> result = new List<User>();

            List<User> listUser = UserDB.GetUsers(IdCompetence, IdActivite);

            // Ici on controle que la personne soit dans le bon canton
            if (IdCanton != 0)
            {
                List<int> listLocalisation = LocalisationDB.GetLocByIdCanton(IdCanton);
                foreach(User user in listUser)
                {
                    foreach(int id in listLocalisation)
                    {
                        if (user.IdLocalisation == id)
                            result.Add(user);
                    }                
                }

                // Retire les users deja selectionnés de la liste
                foreach(User user in result)
                {
                    listUser.Remove(user);
                }
            }

            // Ici on controle que la produise la bonne categorie de ressources
            if (IdProduit != 0)
            {
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
            else if(IdCategorieProduit != 0)
            {

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
    }
}
