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

namespace RkaaAVLS.Areas.Admin
{
    public class MainOrganizationsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/MainOrganizations
        public async Task<ActionResult> Index()
        {

            return View(await db.MainOrganizations.ToListAsync());
          
        }

        // GET: Admin/MainOrganizations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainOrganization mainOrganization = await db.MainOrganizations.FindAsync(id);
            if (mainOrganization == null)
            {
              
                return HttpNotFound();
            }
            return View(mainOrganization);
        }

        // GET: Admin/MainOrganizations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MainOrganizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MainOrganID,MainOrganName,MainOrgManagerName,MainOrgManagerTel")] MainOrganization mainOrganization)
        {
            if (ModelState.IsValid)
            {
                db.MainOrganizations.Add(mainOrganization);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mainOrganization);
        }

        // GET: Admin/MainOrganizations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainOrganization mainOrganization = await db.MainOrganizations.FindAsync(id);
            if (mainOrganization == null)
            {
                return HttpNotFound();
            }
            return View(mainOrganization);
        }

        // POST: Admin/MainOrganizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MainOrganID,MainOrganName,MainOrgManagerName,MainOrgManagerTel")] MainOrganization mainOrganization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mainOrganization).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mainOrganization);
        }

        // GET: Admin/MainOrganizations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainOrganization mainOrganization = await db.MainOrganizations.FindAsync(id);
            if (mainOrganization == null)
            {
                return HttpNotFound();
            }
            return View(mainOrganization);
        }

        // POST: Admin/MainOrganizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MainOrganization mainOrganization = await db.MainOrganizations.FindAsync(id);
            db.MainOrganizations.Remove(mainOrganization);
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
