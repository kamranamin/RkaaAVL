
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;




namespace RkaaAVLS.Models.Entites 
{
    public class DataContext:DbContext
    {
        public DataContext()
        {
            this.Database.Connection.ConnectionString = "server=.;database=RkaaAvlsDB;trusted_connection=true";
        }
       
       
       
        public DbSet<Models.Entites.GpsData> GpsDatas { get; set; }
        public DbSet<Models.Entites.MainOrganization> MainOrganizations { get; set; }
        public DbSet<Models.Entites.Role> Role { get; set; }
        public DbSet<Models.Entites.SubOrganization> subOrganizations { get; set; }
        public DbSet<Models.Entites.Vehicle> Vehicles { get; set; }
        public DbSet<Models.Entites.Users> users { get; set; }
        public DbSet<Models.Entites.Vehicletype> Vehicletypes { get; set; }

    }
}
