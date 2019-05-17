using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alimenterre3.ViewModels;
using BLL;

namespace Alimenterre3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Signin()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Affichage()
        {
            RechercheVM vm = new RechercheVM();
            return View(vm);
        }

        [HttpPost]
        public ActionResult(RechercheVM vm)
        {
            string NomCanton = vm.canton;
            string NomProduit = vm.produit;
            string NomCategorie = vm.typeProduit;
            string NomCompetence = vm.competences;
            string NomActivite = vm.activite;




               
        }
    }
}