using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RkaaAVLS.Models.Entites
{
    public class Vehicletype
    {
        [Key]
        public int TypeId { get; set; }

        public string TypeName { get; set; }
        public virtual ICollection<Vehicle> vehicles { get; set; }
    }
}
