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

namespace RkaaAVLS.Areas.MainCo.Controllers
{
    public class VehiclesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: MainCo/Vehicles
        public async Task<ActionResult> Index()
        {
            var vehicles = db.Vehicles.Include(v => v.SubOrganization).Include(v => v.vehichtype);
            return View(await vehicles.ToListAsync());
        }

        // GET: MainCo/Vehicles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = await db.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: MainCo/Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.SubOrganID = new SelectList(db.subOrganizations, "SubOrganID", "SubOrganName");
            ViewBag.TypeId = new SelectList(db.Vehicletypes, "TypeId", "TypeName");
            return View();
        }

        // POST: MainCo/Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VehicleId,Imei,VehicleName,VehicleNo,SimcardNo,SubOrganID,DriverName,DriverAddress,DriverPhoneNo,PolicyStartDate,PolicyEndDate,DriverImage,RegisterDate,ExpireDate,TypeId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SubOrganID = new SelectList(db.subOrganizations, "SubOrganID", "SubOrganName", vehicle.SubOrganID);
            ViewBag.TypeId = new SelectList(db.Vehicletypes, "TypeId", "TypeName", vehicle.TypeId);
            return View(vehicle);
        }

        // GET: MainCo/Vehicles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = await db.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubOrganID = new SelectList(db.subOrganizations, "SubOrganID", "SubOrganName", vehicle.SubOrganID);
            ViewBag.TypeId = new SelectList(db.Vehicletypes, "TypeId", "TypeName", vehicle.TypeId);
            return View(vehicle);
        }

        // POST: MainCo/Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VehicleId,Imei,VehicleName,VehicleNo,SimcardNo,SubOrganID,DriverName,DriverAddress,DriverPhoneNo,PolicyStartDate,PolicyEndDate,DriverImage,RegisterDate,ExpireDate,TypeId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SubOrganID = new SelectList(db.subOrganizations, "SubOrganID", "SubOrganName", vehicle.SubOrganID);
            ViewBag.TypeId = new SelectList(db.Vehicletypes, "TypeId", "TypeName", vehicle.TypeId);
            return View(vehicle);
        }

        // GET: MainCo/Vehicles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = await db.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: MainCo/Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Vehicle vehicle = await db.Vehicles.FindAsync(id);
            db.Vehicles.Remove(vehicle);
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
