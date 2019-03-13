using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RkaaAVLS.ViewModels
{
    public class VehicleViewModel
    {
        public int VehicleId { get; set; }
       
       
        public string Imei { get; set; }

       
        public string VehicleName { get; set; }
       
        public string VehicleNo { get; set; }
        
        public string SimcardNo { get; set; }


       
        public int SubOrganID { get; set; }
       
      

       
        public int DriverName { get; set; }
        
        public string DriverAddress { get; set; }
       
        public string DriverPhoneNo { get; set; }

      
        public DateTime PolicyStartDate { get; set; }
      
        public DateTime PolicyEndDate { get; set; }
      
        public byte[] DriverImage { get; set; }

        public DateTime RegisterDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int TypeId { get; set; }
    }
}