using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

            List<User> users = new List<User>();
             users = UserManager.GetUsers();

            return View(users);
        }
        [HttpGet]
        public ActionResult AffichageProducteur()
        {
            User user = new User();
            user = UserManager.getInfos();
            return View(user);
        }
    }
}