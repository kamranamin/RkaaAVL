using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RkaaAVLS.Models.Entites
{
    public class MainOrganization
    {
        [Key]
        public int MainOrganID { get; set; }
        [Display(Name ="نام ارگان ")]
        [Required(ErrorMessage ="لطفا نام ارگان را وارد نمایید !")]
        public string MainOrganName { get; set; }
        [Display(Name = "نام مدیر ارگان ")]
        [Required(ErrorMessage = "لطفا نام  مدیر ارگان را وارد نمایید !")]
        public string MainOrgManagerName { get; set; }
        [Display(Name = "شماره تماس مدیر ارگان ")]
        [Required(ErrorMessage = "لطفا شماره تماس  مدیر ارگان را وارد نمایید !")]
        public string MainOrgManagerTel { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }
        public virtual ICollection<SubOrganization> SubOrganizations { get; set; }
        


    }
}
