using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace ArkaServices.Model
{
    class Context:DbContext
    {
        public Context()
        {
            this.Database.Connection.ConnectionString = "server=.;database=RkaaAvlsDB;trusted_connection=true";
        }
        public DbSet<GpsData> GpsData { get; set; }

    }
}
