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
    public class LichChieuxController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/LichChieux
        public ActionResult Index()
        {
            var lichChieux = db.LichChieux.Include(l => l.DinhDangPhim).Include(l => l.Phim).Include(l => l.PhongChieu);
            return View(lichChieux.ToList());
        }

        // GET: Admin/LichChieux/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichChieu lichChieu = db.LichChieux.Find(id);
            if (lichChieu == null)
            {
                return HttpNotFound();
            }
            return View(lichChieu);
        }

        // GET: Admin/LichChieux/Create
        public ActionResult Create()
        {
            ViewBag.IdDinhDangPhim = new SelectList(db.DinhDangPhims, "Id", "DinhDang");
            ViewBag.IdPhim = new SelectList(db.Phims, "Id", "TenPhim");
            ViewBag.IdPhongChieu = new SelectList(db.PhongChieux, "Id", "TenPhong");
            return View();
        }

        // POST: Admin/LichChieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NgayChieu,GioBatDau,GioKetThuc,IdPhim,IdPhongChieu,IdDinhDangPhim")] LichChieu lichChieu)
        {
            if (ModelState.IsValid)
            {
                db.LichChieux.Add(lichChieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDinhDangPhim = new SelectList(db.DinhDangPhims, "Id", "DinhDang", lichChieu.IdDinhDangPhim);
            ViewBag.IdPhim = new SelectList(db.Phims, "Id", "TenPhim", lichChieu.IdPhim);
            ViewBag.IdPhongChieu = new SelectList(db.PhongChieux, "Id", "TenPhong", lichChieu.IdPhongChieu);
            return View(lichChieu);
        }

        // GET: Admin/LichChieux/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichChieu lichChieu = db.LichChieux.Find(id);
            if (lichChieu == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDinhDangPhim = new SelectList(db.DinhDangPhims, "Id", "DinhDang", lichChieu.IdDinhDangPhim);
            ViewBag.IdPhim = new SelectList(db.Phims, "Id", "TenPhim", lichChieu.IdPhim);
            ViewBag.IdPhongChieu = new SelectList(db.PhongChieux, "Id", "TenPhong", lichChieu.IdPhongChieu);
            return View(lichChieu);
        }

        // POST: Admin/LichChieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NgayChieu,GioBatDau,GioKetThuc,IdPhim,IdPhongChieu,IdDinhDangPhim")] LichChieu lichChieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lichChieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDinhDangPhim = new SelectList(db.DinhDangPhims, "Id", "DinhDang", lichChieu.IdDinhDangPhim);
            ViewBag.IdPhim = new SelectList(db.Phims, "Id", "TenPhim", lichChieu.IdPhim);
            ViewBag.IdPhongChieu = new SelectList(db.PhongChieux, "Id", "TenPhong", lichChieu.IdPhongChieu);
            return View(lichChieu);
        }

        // GET: Admin/LichChieux/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichChieu lichChieu = db.LichChieux.Find(id);
            if (lichChieu == null)
            {
                return HttpNotFound();
            }
            return View(lichChieu);
        }

        // POST: Admin/LichChieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LichChieu lichChieu = db.LichChieux.Find(id);
            db.LichChieux.Remove(lichChieu);
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
