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
    public class DatVesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/DatVes
        public ActionResult Index()
        {
            var datVes = db.DatVes.Include(d => d.KhachHang).Include(d => d.Ve);
            return View(datVes.ToList());
        }

        // GET: Admin/DatVes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatVe datVe = db.DatVes.Find(id);
            if (datVe == null)
            {
                return HttpNotFound();
            }
            return View(datVe);
        }

        // GET: Admin/DatVes/Create
        public ActionResult Create()
        {
            ViewBag.IdKH = new SelectList(db.KhachHangs, "Id", "TenKH");
            ViewBag.IdVe = new SelectList(db.Ves, "Id", "Id");
            return View();
        }

        // POST: Admin/DatVes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdVe,IdKH,NgayDat")] DatVe datVe)
        {
            if (ModelState.IsValid)
            {
                db.DatVes.Add(datVe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdKH = new SelectList(db.KhachHangs, "Id", "TenKH", datVe.IdKH);
            ViewBag.IdVe = new SelectList(db.Ves, "Id", "Id", datVe.IdVe);
            return View(datVe);
        }

        // GET: Admin/DatVes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatVe datVe = db.DatVes.Find(id);
            if (datVe == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdKH = new SelectList(db.KhachHangs, "Id", "TenKH", datVe.IdKH);
            ViewBag.IdVe = new SelectList(db.Ves, "Id", "Id", datVe.IdVe);
            return View(datVe);
        }

        // POST: Admin/DatVes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdVe,IdKH,NgayDat")] DatVe datVe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datVe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdKH = new SelectList(db.KhachHangs, "Id", "TenKH", datVe.IdKH);
            ViewBag.IdVe = new SelectList(db.Ves, "Id", "Id", datVe.IdVe);
            return View(datVe);
        }

        // GET: Admin/DatVes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatVe datVe = db.DatVes.Find(id);
            if (datVe == null)
            {
                return HttpNotFound();
            }
            return View(datVe);
        }

        // POST: Admin/DatVes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatVe datVe = db.DatVes.Find(id);
            db.DatVes.Remove(datVe);
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
