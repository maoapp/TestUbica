using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestUbica.Models;

namespace TestUbica.Controllers
{
    public class MvtoesController : Controller
    {
        private TestUbicaContext db = new TestUbicaContext();

        // GET: Mvtoes
        public ActionResult Index()
        {
            var mvtoes = db.Mvtoes.Include(m => m.Third);
            return View(mvtoes.ToList());
        }

        // GET: Mvtoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mvto mvto = db.Mvtoes.Find(id);
            if (mvto == null)
            {
                return HttpNotFound();
            }
            return View(mvto);
        }

        // GET: Mvtoes/Create
        public ActionResult Create()
        {
            ViewBag.ThirdId = new SelectList(db.Thirds, "ThirdId", "Name");
            return View();
        }

        // POST: Mvtoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MvtoId,Date,ThirdId")] Mvto mvto)
        {
            if (ModelState.IsValid)
            {
                db.Mvtoes.Add(mvto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ThirdId = new SelectList(db.Thirds, "ThirdId", "Name", mvto.ThirdId);
            return View(mvto);
        }

        // GET: Mvtoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mvto mvto = db.Mvtoes.Find(id);
            if (mvto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ThirdId = new SelectList(db.Thirds, "ThirdId", "Name", mvto.ThirdId);
            return View(mvto);
        }

        // POST: Mvtoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MvtoId,Date,ThirdId")] Mvto mvto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mvto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ThirdId = new SelectList(db.Thirds, "ThirdId", "Name", mvto.ThirdId);
            return View(mvto);
        }

        // GET: Mvtoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mvto mvto = db.Mvtoes.Find(id);
            if (mvto == null)
            {
                return HttpNotFound();
            }
            return View(mvto);
        }

        // POST: Mvtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mvto mvto = db.Mvtoes.Find(id);
            db.Mvtoes.Remove(mvto);
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
