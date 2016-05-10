using System.Net.Http.Formatting;
using System.Web.Http;
using WeChatPortal.Filters;

namespace WeChatPortal
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new ApiActionFilterAttribute());
            config.Filters.Add(new ApiExceptionFilterAttribute());

            config.Formatters.Remove(config.Formatters.XmlFormatter);

        }
    }
}
