using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocalsScout.Controllers
{
    public class KategoriiController : Controller
    {
        // GET: Kategorii
        //returns view for bakeries 
        public ActionResult Bakeries()
        {
            return View();
        }

        //returns view for Cafee 
        public ActionResult Cafee()
        {
            return View();
        }

        //returns view for Hotels
        public ActionResult Hotels()
        {
            return View();
        }

        //returns view for Hairdressers
        public ActionResult Hairdressers()
        {
            return View();
        }

        //returns view for Clothes
        public ActionResult Clothes()
        {
            return View();
        }

    }
}