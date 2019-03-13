using System.Web.Mvc;

namespace RkaaAVLS.Areas.MainCo
{
    public class MainCoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MainCo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MainCo_default",
                "MainCo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}