using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookingTicket.Models;

namespace BookingTicket.Controllers
{
    public class VesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Ves
        public ActionResult Index()
        {
            var ves = db.Ves.Include(v => v.Ghe).Include(v => v.LichChieu).Include(v => v.NhanVien);
            return View(ves.ToList());
        }

        public ActionResult Index1(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var all_ve = (from s in db.Ves select s).Where(p => p.IdLichChieu == id);
            return View(all_ve);
        }

        // GET: Ves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ve ve = db.Ves.Find(id);
            if (ve == null)
            {
                return HttpNotFound();
            }
            return View(ve);
        }

        // GET: Ves/Create
        public ActionResult Create()
        {
            ViewBag.IdGhe = new SelectList(db.Ghes, "Id", "Row");
            ViewBag.IdLichChieu = new SelectList(db.LichChieux, "Id", "Id");
            ViewBag.IdNhanVien = new SelectList(db.NhanViens, "Id", "TenNV");
            return View();
        }

        // POST: Ves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdLichChieu,IdGhe,IdNhanVien,DaBan,GiaBan")] Ve ve)
        {
            if (ModelState.IsValid)
            {
                db.Ves.Add(ve);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdGhe = new SelectList(db.Ghes, "Id", "Row", ve.IdGhe);
            ViewBag.IdLichChieu = new SelectList(db.LichChieux, "Id", "Id", ve.IdLichChieu);
            ViewBag.IdNhanVien = new SelectList(db.NhanViens, "Id", "TenNV", ve.IdNhanVien);
            return View(ve);
        }

        // GET: Ves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ve ve = db.Ves.Find(id);
            if (ve == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdGhe = new SelectList(db.Ghes, "Id", "Row", ve.IdGhe);
            ViewBag.IdLichChieu = new SelectList(db.LichChieux, "Id", "Id", ve.IdLichChieu);
            ViewBag.IdNhanVien = new SelectList(db.NhanViens, "Id", "TenNV", ve.IdNhanVien);
            return View(ve);
        }

        // POST: Ves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdLichChieu,IdGhe,IdNhanVien,DaBan,GiaBan")] Ve ve)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ve).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdGhe = new SelectList(db.Ghes, "Id", "Row", ve.IdGhe);
            ViewBag.IdLichChieu = new SelectList(db.LichChieux, "Id", "Id", ve.IdLichChieu);
            ViewBag.IdNhanVien = new SelectList(db.NhanViens, "Id", "TenNV", ve.IdNhanVien);
            return View(ve);
        }

        // GET: Ves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ve ve = db.Ves.Find(id);
            if (ve == null)
            {
                return HttpNotFound();
            }
            return View(ve);
        }

        // POST: Ves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ve ve = db.Ves.Find(id);
            db.Ves.Remove(ve);
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
