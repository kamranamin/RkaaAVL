namespace ArkaServices
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vehicle")]
    public partial class Vehicle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicle()
        {
            GpsData = new HashSet<GpsData>();
        }

        public int VehicleId { get; set; }

        [Required]
        public string Imei { get; set; }

        [Required]
        public string VehicleName { get; set; }

        [Required]
        public string VehicleNo { get; set; }

        [Required]
        public string SimcardNo { get; set; }

        public int SubOrganID { get; set; }

        public int DriverName { get; set; }

        [Required]
        public string DriverAddress { get; set; }

        [Required]
        public string DriverPhoneNo { get; set; }

        public DateTime PolicyStartDate { get; set; }

        public DateTime PolicyEndDate { get; set; }

        public byte[] DriverImage { get; set; }

        public DateTime RegisterDate { get; set; }

        public DateTime ExpireDate { get; set; }

        public int TypeId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GpsData> GpsData { get; set; }
    }
}
