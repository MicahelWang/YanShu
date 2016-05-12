using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WeChatPortal.Utils;

namespace WeChatPortal
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {
            var error = Server.GetLastError();
            var code = (error as HttpException)?.GetHttpCode() ?? 500;

            if (code != 404)
            {
                // Generate email with error details and send to administrator
                // I'm using RazorMail which can be downloaded from the Nuget Gallery
                // I also have an extension method on type Exception that creates a string representation
            }
            string path = Request.Path;
            var msg = string.Format("Url:{0},HttpCode:{1}", path,code);
            Log4NetHelper.WriteError(msg, error);
            Response.Clear();
            Server.ClearError();
        }
    }
}
