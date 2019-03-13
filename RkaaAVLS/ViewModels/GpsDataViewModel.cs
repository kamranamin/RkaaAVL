using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RkaaAVLS.ViewModels
{
    public class GpsDataViewModel
    {
        public float  X { get; set; }
        public float Y { get; set; }
        public VehicleViewModel Vehicle { get; set; }

    }
}