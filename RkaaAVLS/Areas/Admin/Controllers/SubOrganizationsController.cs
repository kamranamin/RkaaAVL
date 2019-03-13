using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Index()
        {
            var subOrganizations = db.subOrganizations.Include(s => s.MainOrganization);
            return View(await subOrganizations.ToListAsync());
        }

        // GET: Admin/SubOrganizations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubOrganization subOrganization = await db.subOrganizations.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "SubOrganID,SubOrganName,SubOrgManagerName,SunOrgManagerTel,MainOrganId")] SubOrganization subOrganization)
        {
            if (ModelState.IsValid)
            {
                db.subOrganizations.Add(subOrganization);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MainOrganId = new SelectList(db.MainOrganizations, "MainOrganID", "MainOrganName", subOrganization.MainOrganId);
            return View(subOrganization);
        }

        // GET: Admin/SubOrganizations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubOrganization subOrganization = await db.subOrganizations.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "SubOrganID,SubOrganName,SubOrgManagerName,SunOrgManagerTel,MainOrganId")] SubOrganization subOrganization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subOrganization).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MainOrganId = new SelectList(db.MainOrganizations, "MainOrganID", "MainOrganName", subOrganization.MainOrganId);
            return View(subOrganization);
        }

        // GET: Admin/SubOrganizations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubOrganization subOrganization = await db.subOrganizations.FindAsync(id);
            if (subOrganization == null)
            {
                return HttpNotFound();
            }
            return View(subOrganization);
        }

        // POST: Admin/SubOrganizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SubOrganization subOrganization = await db.subOrganizations.FindAsync(id);
            db.subOrganizations.Remove(subOrganization);
            await db.SaveChangesAsync();
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
