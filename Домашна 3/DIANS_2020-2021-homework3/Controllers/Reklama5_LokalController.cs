using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LocalsScout.Models;

namespace LocalsScout.Controllers
{
    public class Reklama5_LokalController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reklama5_Lokal
        public ActionResult Index()
        {
            return View(db.Reklama5_Lokali.ToList());
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
