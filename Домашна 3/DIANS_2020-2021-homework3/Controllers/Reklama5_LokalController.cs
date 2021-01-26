using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LocalsScout.Models;
using Microsoft.AspNet.Identity;

namespace LocalsScout.Controllers
{
    public class Reklama5_LokalController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var lista_lokali = db.Izbrani_lokali.ToList();

            var user_id= HttpContext.User.Identity.GetUserId();
            var izbrani_lokali = new  List<int>();

            foreach (var lokal in lista_lokali) {
                if (lokal.ApplicationUser_Id == user_id)
                {
                    izbrani_lokali.Add(lokal.Reklama5_Lokal_ID);
                }
                else
                    continue;
             }

            var lokali_za_prikaz = new  List<Reklama5_Lokal>();
            var lokali_5 = db.Reklama5_Lokali.ToList();

            foreach (var lokal in lokali_5)
            {
                var ne_izbran = true;
                foreach(var idto in izbrani_lokali)
                {
                    if(lokal.ID == idto)
                    {
                        ne_izbran = false;
                    }
                }
                if (ne_izbran)
                {
                    lokali_za_prikaz.Add(lokal);
                }
            }
            ViewBag.reklama_5 = lokali_5.Count();
            ViewBag.dolzina = lokali_5.Count() - lokali_za_prikaz.Count();
            return View(lokali_za_prikaz);
        }

        public ActionResult DodadiLokal(int id)
        {
            var user_id = HttpContext.User.Identity.GetUserId();
            ApplicationUserReklama5_Lokal nov = new ApplicationUserReklama5_Lokal { ApplicationUser_Id = user_id, Reklama5_Lokal_ID = id };
            var lokalce = db.Izbrani_lokali.Add(nov);
            db.SaveChanges();
            return RedirectToAction("Index", "Reklama5_Lokal");
        }
        public ActionResult Izbrisi()
        {
            var lista_lokali = db.Izbrani_lokali.ToList();

            var user_id = HttpContext.User.Identity.GetUserId();
            var izbrani_lokali = new List<int>();

            foreach (var lokal in lista_lokali)
            {
                if (lokal.ApplicationUser_Id == user_id)
                {
                    izbrani_lokali.Add(lokal.Reklama5_Lokal_ID);
                }
                else
                    continue;
            }

            var lokali_za_prikaz = new List<Reklama5_Lokal>();
            var lokali_5 = db.Reklama5_Lokali.ToList();

            foreach (var lokal in lokali_5)
            {
                var izbran = false;
                foreach (var idto in izbrani_lokali)
                {
                    if (lokal.ID == idto)
                    {
                        izbran = true;
                        break;
                    }
                }
                if (izbran)
                {
                    lokali_za_prikaz.Add(lokal);
                }
            }
            return View(lokali_za_prikaz);
        }

        public ActionResult IzbrisiLokal(int id)
        {
            var user_id = HttpContext.User.Identity.GetUserId();
            var za_brisenje = db.Izbrani_lokali.Find(user_id, id);
            db.Izbrani_lokali.Remove(za_brisenje);
            db.SaveChanges();
            return RedirectToAction("Izbrisi", "Reklama5_Lokal");
        }

        // GET: Reklama5_Lokal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reklama5_Lokal reklama5_Lokal = db.Reklama5_Lokali.Find(id);
            if (reklama5_Lokal == null)
            {
                return HttpNotFound();
            }
            return View(reklama5_Lokal);
        }

        // GET: Reklama5_Lokal/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reklama5_Lokal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Kvadratura,Longitude,Latitude,Tel,Tip_oglas,Cena")] Reklama5_Lokal reklama5_Lokal)
        {
            if (ModelState.IsValid)
            {
                db.Reklama5_Lokali.Add(reklama5_Lokal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reklama5_Lokal);
        }

        // GET: Reklama5_Lokal/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reklama5_Lokal reklama5_Lokal = db.Reklama5_Lokali.Find(id);
            if (reklama5_Lokal == null)
            {
                return HttpNotFound();
            }
            return View(reklama5_Lokal);
        }

        // POST: Reklama5_Lokal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Kvadratura,Longitude,Latitude,Tel,Tip_oglas,Cena")] Reklama5_Lokal reklama5_Lokal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reklama5_Lokal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reklama5_Lokal);
        }

        // GET: Reklama5_Lokal/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reklama5_Lokal reklama5_Lokal = db.Reklama5_Lokali.Find(id);
            if (reklama5_Lokal == null)
            {
                return HttpNotFound();
            }
            return View(reklama5_Lokal);
        }

        // POST: Reklama5_Lokal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reklama5_Lokal reklama5_Lokal = db.Reklama5_Lokali.Find(id);
            db.Reklama5_Lokali.Remove(reklama5_Lokal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
