using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewPizza.Models;

namespace NewPizza.Controllers
{
    public class SepetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sepets
        public ActionResult Index()
        {
            var sepets = db.Sepets.Include(s => s.Urun);
            return View(sepets.ToList());
        }

        // GET: Sepets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sepet sepet = db.Sepets.Find(id);
            if (sepet == null)
            {
                return HttpNotFound();
            }
            return View(sepet);
        }

        // GET: Sepets/Create
        public ActionResult Create()
        {
            ViewBag.UrunId = new SelectList(db.Uruns, "Id", "Ad");
            return View();
        }

        // POST: Sepets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UrunId,Adet,UserId")] Sepet sepet)
        {
            if (ModelState.IsValid)
            {
                db.Sepets.Add(sepet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UrunId = new SelectList(db.Uruns, "Id", "Ad", sepet.UrunId);
            return View(sepet);
        }

        // GET: Sepets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sepet sepet = db.Sepets.Find(id);
            if (sepet == null)
            {
                return HttpNotFound();
            }
            ViewBag.UrunId = new SelectList(db.Uruns, "Id", "Ad", sepet.UrunId);
            return View(sepet);
        }

        // POST: Sepets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UrunId,Adet,UserId")] Sepet sepet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sepet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UrunId = new SelectList(db.Uruns, "Id", "Ad", sepet.UrunId);
            return View(sepet);
        }

        // GET: Sepets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sepet sepet = db.Sepets.Find(id);
            if (sepet == null)
            {
                return HttpNotFound();
            }
            return View(sepet);
        }

        // POST: Sepets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sepet sepet = db.Sepets.Find(id);
            db.Sepets.Remove(sepet);
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
