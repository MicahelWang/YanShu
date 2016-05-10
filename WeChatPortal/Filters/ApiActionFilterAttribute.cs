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
            ResponseEntity<object> result = new ResponseEntity<object>();

            // 取得由 API 返回的状态代码
            result.Success = actionExecutedContext.ActionContext.Response.StatusCode == HttpStatusCode.OK;
            // 取得由 API 返回的资料
            result.Data = actionExecutedContext.ActionContext.Response.Content.ReadAsAsync<object>().Result;
            // 重新封装回传格式
            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}