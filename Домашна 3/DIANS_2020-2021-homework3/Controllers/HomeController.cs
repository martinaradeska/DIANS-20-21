using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocalsScout.Controllers
{   
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //returns Home Page  
        public ActionResult Index()
        {
            return View();
        }

        //returns view for information about the project
        public ActionResult About()
        {
            ViewBag.Message = "About";

            return View();
        }

    }
}