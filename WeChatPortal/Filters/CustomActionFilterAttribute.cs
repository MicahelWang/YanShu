using System.Web.Mvc;
using WeChatPortal.Utils;

namespace WeChatPortal.Filters
{
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var request = filterContext.RequestContext.HttpContext.Request;
            if (request.Url != null)
            {
                var url = request.Url.AbsoluteUri;
                var queryString = request.Url.Query;
                var requestFormat = "Request Url：\r\n{0}";
                Log4NetHelper.WriteDebug(string.Format(requestFormat, url, queryString));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}