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
        public IEnumerable<string> Canton { get; set; }
        public string SelectedValue { get; set; }
    
        [Display(Name = "Produit")]
        public IEnumerable<string> Produit { get; set; }
        public string SelectedValue2 { get; set; }

        [Display(Name = "Type de Produit")]
        public IEnumerable<string> Categorie { get; set; }
        public string SelectedValue3 { get; set; }

        [Display(Name = "Compétences")]
        public IEnumerable<string> Competences { get; set; }
        public string SelectedValue4 { get; set; }
  
        [Display(Name =  "Activité")]
        public IEnumerable<string> Activite { get; set; }
        public string SelectedValue5 { get; set; }
        
    }
}