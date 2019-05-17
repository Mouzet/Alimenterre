using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class User
    {
        public int IdUser { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Societe { get; set; }
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public string Mail { get; set; }
        public string Description { get; set; }
        public int IdCompetence { get; set; }
        public int IdActivite { get; set; }
        public int IdLocalisation { get; set; }
        public int IdCategoryUser { get; set; }
        
    }
}
