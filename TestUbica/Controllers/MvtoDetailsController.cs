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
    public class MvtoDetailsController : Controller
    {
        private TestUbicaContext db = new TestUbicaContext();

        // GET: MvtoDetails
        public ActionResult Index()
        {
            var mvtoDetails = db.MvtoDetails.Include(m => m.Mvto).Include(m => m.Product);
            return View(mvtoDetails.ToList());
        }

        // GET: MvtoDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MvtoDetail mvtoDetail = db.MvtoDetails.Find(id);
            if (mvtoDetail == null)
            {
                return HttpNotFound();
            }
            return View(mvtoDetail);
        }

        // GET: MvtoDetails/Create
        public ActionResult Create()
        {
            ViewBag.MvtoId = new SelectList(db.Mvtoes, "MvtoId", "MvtoId");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Description");
            return View();
        }

        // POST: MvtoDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MvtoDetailId,Quantity,Date,ProductId,MvtoId")] MvtoDetail mvtoDetail)
        {
            if (ModelState.IsValid)
            {
                db.MvtoDetails.Add(mvtoDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MvtoId = new SelectList(db.Mvtoes, "MvtoId", "MvtoId", mvtoDetail.MvtoId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Description", mvtoDetail.ProductId);
            return View(mvtoDetail);
        }

        // GET: MvtoDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MvtoDetail mvtoDetail = db.MvtoDetails.Find(id);
            if (mvtoDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.MvtoId = new SelectList(db.Mvtoes, "MvtoId", "MvtoId", mvtoDetail.MvtoId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Description", mvtoDetail.ProductId);
            return View(mvtoDetail);
        }

        // POST: MvtoDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MvtoDetailId,Quantity,Date,ProductId,MvtoId")] MvtoDetail mvtoDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mvtoDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MvtoId = new SelectList(db.Mvtoes, "MvtoId", "MvtoId", mvtoDetail.MvtoId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Description", mvtoDetail.ProductId);
            return View(mvtoDetail);
        }

        // GET: MvtoDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MvtoDetail mvtoDetail = db.MvtoDetails.Find(id);
            if (mvtoDetail == null)
            {
                return HttpNotFound();
            }
            return View(mvtoDetail);
        }

        // POST: MvtoDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MvtoDetail mvtoDetail = db.MvtoDetails.Find(id);
            db.MvtoDetails.Remove(mvtoDetail);
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
