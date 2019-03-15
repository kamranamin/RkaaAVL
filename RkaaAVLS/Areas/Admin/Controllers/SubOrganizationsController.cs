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
    public class SubOrganizationsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/SubOrganizations
        public ActionResult Index()
        {
            var subOrganizations = db.subOrganizations.Include(s => s.MainOrganization);
            return View(subOrganizations.ToList());
        }

        // GET: Admin/SubOrganizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubOrganization subOrganization = db.subOrganizations.Find(id);
            if (subOrganization == null)
            {
                return HttpNotFound();
            }
            return View(subOrganization);
        }

        // GET: Admin/SubOrganizations/Create
        public ActionResult Create()
        {
            ViewBag.MainOrganId = new SelectList(db.MainOrganizations, "MainOrganID", "MainOrganName");
            return View();
        }

        // POST: Admin/SubOrganizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubOrganID,SubOrganName,SubOrgManagerName,SunOrgManagerTel,MainOrganId")] SubOrganization subOrganization)
        {
            if (ModelState.IsValid)
            {
                db.subOrganizations.Add(subOrganization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MainOrganId = new SelectList(db.MainOrganizations, "MainOrganID", "MainOrganName", subOrganization.MainOrganId);
            return View(subOrganization);
        }

        // GET: Admin/SubOrganizations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubOrganization subOrganization = db.subOrganizations.Find(id);
            if (subOrganization == null)
            {
                return HttpNotFound();
            }
            ViewBag.MainOrganId = new SelectList(db.MainOrganizations, "MainOrganID", "MainOrganName", subOrganization.MainOrganId);
            return View(subOrganization);
        }

        // POST: Admin/SubOrganizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubOrganID,SubOrganName,SubOrgManagerName,SunOrgManagerTel,MainOrganId")] SubOrganization subOrganization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subOrganization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MainOrganId = new SelectList(db.MainOrganizations, "MainOrganID", "MainOrganName", subOrganization.MainOrganId);
            return View(subOrganization);
        }

        // GET: Admin/SubOrganizations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubOrganization subOrganization = db.subOrganizations.Find(id);
            if (subOrganization == null)
            {
                return HttpNotFound();
            }
            return View(subOrganization);
        }

        // POST: Admin/SubOrganizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubOrganization subOrganization = db.subOrganizations.Find(id);
            db.subOrganizations.Remove(subOrganization);
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
