using System.Web.Http.Filters;
using WeChatPortal.Entities.Data;
using WeChatPortal.Utils;
using WeChatPortal.Utils.Mvc;

namespace WeChatPortal.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
     
        public override void OnException(HttpActionExecutedContext filterContext)
        {
            var bases = filterContext.Request;
            var auroreException = filterContext.Exception as SimpleException;
            var exception = auroreException ?? new SimpleException(filterContext.Exception);
            Log4NetHelper.WriteError("\r\n客户机IP:" + bases.RequestUri.Host + "\r\n错误地址:" + bases.RequestUri.AbsoluteUri + "\r\n异常信息:" + exception.Message, exception);

            var obj = new ResponseEntity<string>()
            {
                Success = false,
                Data = "请求异常",
                ErrorCode = exception.HResult.ToString(),
                ErrorMsg = exception.Message

            };
            filterContext.Response = obj.JsonResponse();
        }
    }
}