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
    public class VaitroesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Admin/Vaitroes
        public ActionResult Index()
        {
            return View(db.Vaitroes.ToList());
        }

        // GET: Admin/Vaitroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaitro vaitro = db.Vaitroes.Find(id);
            if (vaitro == null)
            {
                return HttpNotFound();
            }
            return View(vaitro);
        }

        // GET: Admin/Vaitroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Vaitroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,vaitro1")] Vaitro vaitro)
        {
            if (ModelState.IsValid)
            {
                db.Vaitroes.Add(vaitro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vaitro);
        }

        // GET: Admin/Vaitroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaitro vaitro = db.Vaitroes.Find(id);
            if (vaitro == null)
            {
                return HttpNotFound();
            }
            return View(vaitro);
        }

        // POST: Admin/Vaitroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,vaitro1")] Vaitro vaitro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaitro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vaitro);
        }

        // GET: Admin/Vaitroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaitro vaitro = db.Vaitroes.Find(id);
            if (vaitro == null)
            {
                return HttpNotFound();
            }
            return View(vaitro);
        }

        // POST: Admin/Vaitroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vaitro vaitro = db.Vaitroes.Find(id);
            db.Vaitroes.Remove(vaitro);
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
