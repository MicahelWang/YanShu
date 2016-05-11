
using System.Web;
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
            string url = request.Url.AbsoluteUri;
            string queryString = request.Url.Query;
            string requestFormat = "Request Url：\r\n{0}";
            Log4NetHelper.WriteLog(string.Format(requestFormat, url, queryString));
            base.OnActionExecuting(filterContext);
        }
    }
}