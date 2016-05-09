using System.Web.Mvc;
using WeChatPortal.Filters;

namespace WeChatPortal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomExceptionFilterAttribute());
        }
    }
}
