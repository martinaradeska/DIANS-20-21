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
        public ActionResult Bakeries()
        {
            return View();
        }
        public ActionResult Cafee()
        {
            return View();
        }
        public ActionResult Hotels()
        {
            return View();
        }
        public ActionResult Hairdressers()
        {
            return View();
        }
        public ActionResult Clothes()
        {
            return View();
        }

    }
}