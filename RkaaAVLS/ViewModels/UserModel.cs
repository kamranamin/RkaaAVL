using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RkaaAVLS.ViewModels
{
    public class UserModel
    {
       
           
            public string UserName { get; set; }
         
            public string Password { get; set; }
            [HiddenInput]
            public string ReturnUrl { get; set; }
       
    }
}