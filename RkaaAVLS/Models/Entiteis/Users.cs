using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RkaaAVLS.Models.Entites
{
    [Table("Users")]
    public class Users
    {
     [Key]
        public int UserId { get; set; }
        [Display(Name ="نام کاربری")]
        [Required(ErrorMessage ="لطفا نام کاربری را وارد نمایید !")]
        public string UserName { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفارمز عبور را وارد نمایید !")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "سطح دستری")]
        [Required(ErrorMessage = "لطفا سطح دسترسی را وارد نمایید !")]
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا نام  را وارد نمایید !")]
        public string FullName { get; set; }
        [Display(Name = "تاریخ ثبت نام ")]
        
        public DateTime RegisterDate { get; set; }
       
        public ICollection<MainOrganization> mainOrganizations { get; set; }

    }
}
