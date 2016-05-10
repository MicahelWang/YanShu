using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WeChatPortal.Entities.Data;
using WeChatPortal.Utils;

namespace WeChatPortal.Filters
{
    public class ApiActionFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            var request = actionContext.Request;
            string url = request.RequestUri.AbsoluteUri;
            string queryString = request.RequestUri.Query;
            string requestFormat = "Request Url：\r\n{0},Query;{1}";
            Log4NetHelper.WriteLog(string.Format(requestFormat, url, queryString));
        }


        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            var result = new ResponseEntity<object>
            {
                Success = actionExecutedContext.ActionContext.Response.StatusCode == HttpStatusCode.OK,
                Data = actionExecutedContext.ActionContext.Response.Content.ReadAsAsync<object>().Result
            };
            // 重新封装回传格式
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}