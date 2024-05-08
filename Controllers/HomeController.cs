using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGCTicketSystem.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

          

        public ActionResult Login()
        {
            if ( Session["UserId"] == null )
            {
                return RedirectToAction("Login", "User");
            }
                 
            
            
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Ticketing System.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}