namespace ArkaServices
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<GpsData> GpsData { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }

      
    }
}
