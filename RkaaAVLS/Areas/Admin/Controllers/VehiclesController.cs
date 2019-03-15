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
    public class VehiclesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Admin/Vehicles
        public ActionResult Index()
        {
            var vehicles = db.Vehicles.Include(v => v.SubOrganization).Include(v => v.vehichtype);
            return View(vehicles.ToList());
        }

        // GET: Admin/Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Admin/Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.SubOrganID = new SelectList(db.subOrganizations, "SubOrganID", "SubOrganName");
            ViewBag.TypeId = new SelectList(db.Vehicletypes, "TypeId", "TypeName");
            return View();
        }

        // POST: Admin/Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleId,Imei,VehicleName,VehicleNo,SimcardNo,SubOrganID,DriverName,DriverAddress,DriverPhoneNo,PolicyStartDate,PolicyEndDate,DriverImage,RegisterDate,ExpireDate,TypeId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubOrganID = new SelectList(db.subOrganizations, "SubOrganID", "SubOrganName", vehicle.SubOrganID);
            ViewBag.TypeId = new SelectList(db.Vehicletypes, "TypeId", "TypeName", vehicle.TypeId);
            return View(vehicle);
        }

        // GET: Admin/Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubOrganID = new SelectList(db.subOrganizations, "SubOrganID", "SubOrganName", vehicle.SubOrganID);
            ViewBag.TypeId = new SelectList(db.Vehicletypes, "TypeId", "TypeName", vehicle.TypeId);
            return View(vehicle);
        }

        // POST: Admin/Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleId,Imei,VehicleName,VehicleNo,SimcardNo,SubOrganID,DriverName,DriverAddress,DriverPhoneNo,PolicyStartDate,PolicyEndDate,DriverImage,RegisterDate,ExpireDate,TypeId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubOrganID = new SelectList(db.subOrganizations, "SubOrganID", "SubOrganName", vehicle.SubOrganID);
            ViewBag.TypeId = new SelectList(db.Vehicletypes, "TypeId", "TypeName", vehicle.TypeId);
            return View(vehicle);
        }

        // GET: Admin/Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Admin/Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
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
