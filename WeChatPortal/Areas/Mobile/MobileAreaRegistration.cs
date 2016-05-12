using System.Web.Mvc;

namespace WeChatPortal.Areas.Mobile
{
    public class MobileAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Mobile";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Mobile_default",
                "Mobile/{controller}/{page}/{id}",
                new { action = "Index", page = UrlParameter.Optional, id = UrlParameter.Optional }
            );
        }
    }
}