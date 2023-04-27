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
    public class LoaiPhimsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/LoaiPhims
        public ActionResult Index()
        {
            return View(db.LoaiPhims.ToList());
        }

        // GET: Admin/LoaiPhims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiPhim loaiPhim = db.LoaiPhims.Find(id);
            if (loaiPhim == null)
            {
                return HttpNotFound();
            }
            return View(loaiPhim);
        }

        // GET: Admin/LoaiPhims/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiPhims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TenLoaiPhim")] LoaiPhim loaiPhim)
        {
            if (ModelState.IsValid)
            {
                db.LoaiPhims.Add(loaiPhim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiPhim);
        }

        // GET: Admin/LoaiPhims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiPhim loaiPhim = db.LoaiPhims.Find(id);
            if (loaiPhim == null)
            {
                return HttpNotFound();
            }
            return View(loaiPhim);
        }

        // POST: Admin/LoaiPhims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TenLoaiPhim")] LoaiPhim loaiPhim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiPhim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiPhim);
        }

        // GET: Admin/LoaiPhims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiPhim loaiPhim = db.LoaiPhims.Find(id);
            if (loaiPhim == null)
            {
                return HttpNotFound();
            }
            return View(loaiPhim);
        }

        // POST: Admin/LoaiPhims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiPhim loaiPhim = db.LoaiPhims.Find(id);
            db.LoaiPhims.Remove(loaiPhim);
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
