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
    public class ThirdsController : Controller
    {
        private TestUbicaContext db = new TestUbicaContext();

        // GET: Thirds
        public ActionResult Index()
        {
            return View(db.Thirds.ToList());
        }

        public JsonResult GetCompanies()
        {
            var companies = db.Thirds.ToList();
            return Json(companies, JsonRequestBehavior.AllowGet);
        }

        // GET: Thirds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Third third = db.Thirds.Find(id);
            if (third == null)
            {
                return HttpNotFound();
            }
            return View(third);
        }

        // GET: Thirds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Thirds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]  
        public ActionResult Create([Bind(Include = "ThirdId,Name,quota")] Third third)
        {
            if (ModelState.IsValid)
            {
                db.Thirds.Add(third);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(third);
        }

        // GET: Thirds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Third third = db.Thirds.Find(id);
            if (third == null)
            {
                return HttpNotFound();
            }
            return View(third);
        }

        // POST: Thirds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ThirdId,Name,quota")] Third third)
        {
            if (ModelState.IsValid)
            {
                db.Entry(third).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(third);
        }

        // GET: Thirds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Third third = db.Thirds.Find(id);
            if (third == null)
            {
                return HttpNotFound();
            }
            return View(third);
        }

        // POST: Thirds/Delete/5
        [HttpPost, ActionName("Delete")]      
        public ActionResult DeleteConfirmed(int id)
        {
            Third third = db.Thirds.Find(id);
            db.Thirds.Remove(third);
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
