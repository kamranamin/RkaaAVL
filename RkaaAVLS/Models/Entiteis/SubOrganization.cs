using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RkaaAVLS.Models.Entites
{
    public class SubOrganization
    {
        [Key]
        public int SubOrganID { get; set; }
        [Display(Name = "نام مجوعه ")]
        [Required(ErrorMessage = "لطفا نام ارگان را وارد نمایید !")]
        public string SubOrganName { get; set; }
        [Display(Name = "نام مدیر مجوعه ")]
        [Required(ErrorMessage = "لطفا نام  مدیر مجوعه را وارد نمایید !")]
        public string SubOrgManagerName { get; set; }
        [Display(Name = "شماره تماس مدیر مجوعه ")]
        [Required(ErrorMessage = "لطفا شماره تماس  مدیر مجوعه را وارد نمایید !")]
        public string SunOrgManagerTel { get; set; }
       
        public int MainOrganId { get; set; }
        [ForeignKey("MainOrganId")]

        [Display(Name = "مدیر ارگان ")]
        [Required(ErrorMessage = "لطفا   مدیر ارگان را وارد نمایید !")]
        public virtual MainOrganization MainOrganization { get; set; }
        
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
