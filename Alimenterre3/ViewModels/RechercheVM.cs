using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alimenterre3.ViewModels
{
    public class RechercheVM
    {
  
        [Display(Name = "Canton")]
        public string canton { get; set; }
    
        [Display(Name = "Produit")]
        public string produit { get; set; }

        [Display(Name = "Type de Produit")]
        public string typeProduit { get; set; }

        [Display(Name = "Compétences")]
        public string competences { get; set; }
  
        [Display(Name =  "Activité")]
        public string activite { get; set; }
        
    }
}