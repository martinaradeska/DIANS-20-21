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
    public class LokalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lokals
        public ActionResult Index()
        {
            return View(db.Lokali.ToList());
        }

        // GET: Lokals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokal lokal = db.Lokali.Find(id);
            if (lokal == null)
            {
                return HttpNotFound();
            }
            return View(lokal);
        }

        // GET: Lokals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lokals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Latitude,Longitude,Name")] Lokal lokal)
        {
            if (ModelState.IsValid)
            {
                db.Lokali.Add(lokal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lokal);
        }

        // GET: Lokals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokal lokal = db.Lokali.Find(id);
            if (lokal == null)
            {
                return HttpNotFound();
            }
            return View(lokal);
        }

        // POST: Lokals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Latitude,Longitude,Name")] Lokal lokal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lokal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lokal);
        }

        // GET: Lokals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokal lokal = db.Lokali.Find(id);
            if (lokal == null)
            {
                return HttpNotFound();
            }
            return View(lokal);
        }

        // POST: Lokals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lokal lokal = db.Lokali.Find(id);
            db.Lokali.Remove(lokal);
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
