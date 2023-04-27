using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DACS.Models;

namespace DACS.Areas.Admin.Controllers
{
    public class GhesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/Ghes
        public ActionResult Index()
        {
            var ghes = db.Ghes.Include(g => g.PhongChieu);
            return View(ghes.ToList());
        }

        // GET: Admin/Ghes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ghe ghe = db.Ghes.Find(id);
            if (ghe == null)
            {
                return HttpNotFound();
            }
            return View(ghe);
        }

        // GET: Admin/Ghes/Create
        public ActionResult Create()
        {
            ViewBag.IdPhongChieu = new SelectList(db.PhongChieux, "Id", "TenPhong");
            return View();
        }

        // POST: Admin/Ghes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Row,Num,Status,IdPhongChieu")] Ghe ghe)
        {
            if (ModelState.IsValid)
            {
                db.Ghes.Add(ghe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPhongChieu = new SelectList(db.PhongChieux, "Id", "TenPhong", ghe.IdPhongChieu);
            return View(ghe);
        }

        // GET: Admin/Ghes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ghe ghe = db.Ghes.Find(id);
            if (ghe == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPhongChieu = new SelectList(db.PhongChieux, "Id", "TenPhong", ghe.IdPhongChieu);
            return View(ghe);
        }

        // POST: Admin/Ghes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Row,Num,Status,IdPhongChieu")] Ghe ghe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ghe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPhongChieu = new SelectList(db.PhongChieux, "Id", "TenPhong", ghe.IdPhongChieu);
            return View(ghe);
        }

        // GET: Admin/Ghes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ghe ghe = db.Ghes.Find(id);
            if (ghe == null)
            {
                return HttpNotFound();
            }
            return View(ghe);
        }

        // POST: Admin/Ghes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ghe ghe = db.Ghes.Find(id);
            db.Ghes.Remove(ghe);
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
