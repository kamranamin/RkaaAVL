using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RkaaAVLS.Models.Entites;

namespace RkaaAVLS.Areas.Admin.Controllers
{
    public class VehicletypesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/Vehicletypes
        public ActionResult Index()
        {
            return View(db.Vehicletypes.ToList());
        }

        // GET: Admin/Vehicletypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicletype vehicletype = db.Vehicletypes.Find(id);
            if (vehicletype == null)
            {
                return HttpNotFound();
            }
            return View(vehicletype);
        }

        // GET: Admin/Vehicletypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Vehicletypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeId,TypeName")] Vehicletype vehicletype)
        {
            if (ModelState.IsValid)
            {
                db.Vehicletypes.Add(vehicletype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicletype);
        }

        // GET: Admin/Vehicletypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicletype vehicletype = db.Vehicletypes.Find(id);
            if (vehicletype == null)
            {
                return HttpNotFound();
            }
            return View(vehicletype);
        }

        // POST: Admin/Vehicletypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeId,TypeName")] Vehicletype vehicletype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicletype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicletype);
        }

        // GET: Admin/Vehicletypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicletype vehicletype = db.Vehicletypes.Find(id);
            if (vehicletype == null)
            {
                return HttpNotFound();
            }
            return View(vehicletype);
        }

        // POST: Admin/Vehicletypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicletype vehicletype = db.Vehicletypes.Find(id);
            db.Vehicletypes.Remove(vehicletype);
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
