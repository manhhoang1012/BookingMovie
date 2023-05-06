using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookingTicket.Models;

namespace BookingTicket.Areas.Admin.Controllers
{
    public class DinhDangPhimsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/DinhDangPhims
        public ActionResult Index()
        {
            return View(db.DinhDangPhims.ToList());
        }

        // GET: Admin/DinhDangPhims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DinhDangPhim dinhDangPhim = db.DinhDangPhims.Find(id);
            if (dinhDangPhim == null)
            {
                return HttpNotFound();
            }
            return View(dinhDangPhim);
        }

        // GET: Admin/DinhDangPhims/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DinhDangPhims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DinhDang")] DinhDangPhim dinhDangPhim)
        {
            if (ModelState.IsValid)
            {
                db.DinhDangPhims.Add(dinhDangPhim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dinhDangPhim);
        }

        // GET: Admin/DinhDangPhims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DinhDangPhim dinhDangPhim = db.DinhDangPhims.Find(id);
            if (dinhDangPhim == null)
            {
                return HttpNotFound();
            }
            return View(dinhDangPhim);
        }

        // POST: Admin/DinhDangPhims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DinhDang")] DinhDangPhim dinhDangPhim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dinhDangPhim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dinhDangPhim);
        }

        // GET: Admin/DinhDangPhims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DinhDangPhim dinhDangPhim = db.DinhDangPhims.Find(id);
            if (dinhDangPhim == null)
            {
                return HttpNotFound();
            }
            return View(dinhDangPhim);
        }

        // POST: Admin/DinhDangPhims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DinhDangPhim dinhDangPhim = db.DinhDangPhims.Find(id);
            db.DinhDangPhims.Remove(dinhDangPhim);
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
