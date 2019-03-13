using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RkaaAVLS.Models.Entites
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Display(Name ="سطح دسترسی ")]
        [Required(ErrorMessage ="لطفا سطح دسترسی را مشخص نماید !")]
        public string RoleName { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
