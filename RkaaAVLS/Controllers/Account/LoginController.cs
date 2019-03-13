using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Http.Owin;


namespace RkaaAVLS.Controllers.Account
{
    public class LoginController : Controller
    {
        // GET: Login
        private readonly Models.Entites.DataContext context = new Models.Entites.DataContext();
        [HttpGet]
        public ActionResult Index( string returnUrl)
        {
            var model = new ViewModels.UserModel()
            {
                ReturnUrl=returnUrl
            };

            

            return View(model );
        }
        [HttpPost]
        public ActionResult Index(ViewModels.UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = context.users.FirstOrDefault(u => u.UserName.ToLower().Equals(userModel.UserName.ToLower()) && u.Password.Equals(userModel.Password));
           
            if(user!=null)
            {
                string Role = "Sub";
                if(user.RoleId==3)
                {
                    Role = "Admin";
                }
                if(user.RoleId==2)
                {
                    Role = "Main";
                }
                if (user.RoleId == 1)
                {
                    Role = "Sub";
                }
                var identity = new ClaimsIdentity(new[]
                 {
                new Claim(ClaimTypes.SerialNumber,user.UserId.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role,Role)
                    }, "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);

                return Redirect(GetRedirectUrl (userModel.ReturnUrl));

            }

            ModelState.AddModelError("", "نام کاربری یا رمز عبور را اشتباه وارد کرده اید.");
            return View();
           
        }
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }
        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("index", "home");
        }
    }
}