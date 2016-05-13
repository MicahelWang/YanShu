using System;
using System.Web.Mvc;
using WeChatPortal.Constants;
using WeChatPortal.Utils;
using WeChatPortal.Utils.HttpUtility;

namespace WeChatPortal.Filters
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class YanShuAuthorizeAttribute : AuthorizeAttribute
    {
        private static readonly string DomainUrl = ConfigSetting.HostUrl;

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated) return;
            var request = filterContext.RequestContext.HttpContext.Request;
            if (request.Url == null) return;
            var userAgent = request.UserAgent;
            var currentUrl = request.Url.AbsoluteUri;
            string url;
            if (userAgent != null && userAgent.ToLower().Contains("micromessenger"))
            {
                var returnUrl = DomainUrl+"/Authorize";
                
                url = RequestUrl.GetAuthorize(ConfigSetting.AppId, returnUrl.UrlEncode(), "snsapi_base", currentUrl.UrlEncode());
            }
            else
            {
                url = "/Home/Login?ReturnUrl="+currentUrl.UrlEncode();
            }
            filterContext.HttpContext.Response.Redirect(url);
        }
    }
}