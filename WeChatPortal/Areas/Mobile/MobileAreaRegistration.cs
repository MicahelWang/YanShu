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
               "Mobile/{controller}",
               new { action = "Index" }
           );
            context.MapRoute(
                "Mobile_default1",
                "Mobile/{controller}/{arg}",
                new { action = "Index" }
            );
            context.MapRoute(
                "Mobile_default2",
                "Mobile/{controller}/{arg1}/{arg2}",
                new { action = "Index" }
            );
            context.MapRoute(
                "Mobile_default3",
                "Mobile/{controller}/{arg1}/{arg2}/{arg3}",
                new { action = "Index" }
            );
            context.MapRoute(
              "Mobile_Api",
              "MobileApi/{controller}/{action}/{id}",
              new { controller = "Home", action = "Index", id = UrlParameter.Optional }
          );
        }
    }
}