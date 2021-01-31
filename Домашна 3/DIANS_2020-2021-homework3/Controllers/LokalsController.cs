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
    //for admin role only
    public class LokalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lokals
        //returns view with all lokals
        public ActionResult Index()
        {
            return View(db.Lokali.ToList());
        }

        // GET: Lokals/Details/5
        /*returns view with details about the chosen lokal where lokal's id is url's parametar 
         * input: null
         * output: bad request
         * input: integer
         * output: if found in db.Lokali returns View(lokal), else HttpNotFound()
        */
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
        //returns view where the admin can create new lokal
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lokals/Create
        //creates new lokal and adds it to db.Lokali
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
        /*returns view where the admin can edit the lokal where lokal's id is url's parametar 
         * input: null
         * output: bad request
         * input: integer
         * output: if found in db.Lokali returns View(lokal), else HttpNotFound()
        */
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
        //changes to the lokal where lokal's id is url's parametar 
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
        /*returns view where the admin can delete the lokal where lokal's id is url's parametar 
         * input: null
         * output: bad request
         * input: integer
         * output: if found in db.Lokali returns View(lokal), else HttpNotFound()
        */
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
        //deletion of the lokal where lokal's id is url's parametar 
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
