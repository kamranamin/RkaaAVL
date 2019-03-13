using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RkaaAVLS.Areas.MainCo
{
    public class VehicleController : Admin.Controllers.VehiclesController
    {
        // GET: MainCo/Vehicle
        public ActionResult Index()
        {
            return View();
        }
    }
}