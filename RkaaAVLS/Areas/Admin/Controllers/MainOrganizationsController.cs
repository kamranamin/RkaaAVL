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
    public class MainOrganizationsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/MainOrganizations
        public ActionResult Index()
        {
            var mainOrganizations = db.MainOrganizations.Include(m => m.Users);
            return View(mainOrganizations.ToList());
        }

        // GET: Admin/MainOrganizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainOrganization mainOrganization = db.MainOrganizations.Find(id);
            if (mainOrganization == null)
            {
                return HttpNotFound();
            }
            return View(mainOrganization);
        }

        // GET: Admin/MainOrganizations/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.users, "UserId", "UserName");
            return View();
        }

        // POST: Admin/MainOrganizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MainOrganID,MainOrganName,MainOrgManagerName,MainOrgManagerTel,UserId")] MainOrganization mainOrganization)
        {
            if (ModelState.IsValid)
            {
                db.MainOrganizations.Add(mainOrganization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.users, "UserId", "UserName", mainOrganization.UserId);
            return View(mainOrganization);
        }

        // GET: Admin/MainOrganizations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainOrganization mainOrganization = db.MainOrganizations.Find(id);
            if (mainOrganization == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.users, "UserId", "UserName", mainOrganization.UserId);
            return View(mainOrganization);
        }

        // POST: Admin/MainOrganizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MainOrganID,MainOrganName,MainOrgManagerName,MainOrgManagerTel,UserId")] MainOrganization mainOrganization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mainOrganization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.users, "UserId", "UserName", mainOrganization.UserId);
            return View(mainOrganization);
        }

        // GET: Admin/MainOrganizations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainOrganization mainOrganization = db.MainOrganizations.Find(id);
            if (mainOrganization == null)
            {
                return HttpNotFound();
            }
            return View(mainOrganization);
        }

        // POST: Admin/MainOrganizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MainOrganization mainOrganization = db.MainOrganizations.Find(id);
            db.MainOrganizations.Remove(mainOrganization);
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
