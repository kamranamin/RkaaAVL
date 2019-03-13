using RkaaAVLS.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http.Owin;
using System.Web.Security;
using RkaaAVLS.ViewModels;
using Newtonsoft.Json;
using System.Security.Claims;

namespace RkaaAVLS.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _database = new DataContext();
        [HttpGet]
        [Authorize(Roles = "Admin,Main,sub")]
        public ActionResult Index()
        {

            //ClaimsPrincipal principal = HttpContext.User.Identity as ClaimsPrincipal;
            //var getUuserId = new GetUser(principal);
            ViewBag.SubCompanyList = _database.subOrganizations.Where(m => m.MainOrganization.Users.UserName.Equals(HttpContext.User.Identity.Name)).ToList();
            ViewBag.VehList = _database.Vehicles.Where(v => v.SubOrganization.MainOrganization.Users.UserName.Equals(HttpContext.User.Identity.Name)).ToList();
           // ViewBag.SubCompany = _database.subOrganizations.Find()

            return View();
        }
        [HttpPost]

        public JsonResult GetGpsData ( GpsDataRequestViewModel request)
        {
            var gpsDatas = _database.GpsDatas.Where(m => m.Vehiche.SubOrganization.MainOrganization.Users.UserName.Equals(HttpContext.User.Identity.Name)).OrderByDescending(p=>p.Id).ToList();
               
            var gpsDataViewModels = new List<GpsDataViewModel>();
            gpsDatas.ForEach((Models.Entites.GpsData gd) =>
            {
                gpsDataViewModels.Add(new GpsDataViewModel
                {
                    Vehicle = new VehicleViewModel
                    {
                        VehicleId = gd.VehicleId
                    },
                    X = gd.Latitude,
                    Y = gd.Longitude
                });
            });

            return Json(JsonConvert.SerializeObject(gpsDataViewModels));
        }
    }
}