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
            Log4NetHelper.WriteError("\r\n�ͻ���IP:" + bases.RequestUri.Host + "\r\n�����ַ:" + bases.RequestUri.AbsoluteUri + "\r\n�쳣��Ϣ:" + exception.Message, exception);

            var obj = new ResponseEntity<string>()
            {
                Success = false,
                Data = "�����쳣",
                ErrorCode = exception.HResult.ToString(),
                ErrorMsg = exception.Message

            };
            filterContext.Response = obj.JsonResponse();
        }
    }
}