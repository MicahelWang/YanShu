using System;
using System.Web;
using System.Web.Mvc;
using WeChatPortal.Constants;
using WeChatPortal.Utils;
using WeChatPortal.Utils.HttpUtility;

namespace WeChatPortal.Filters
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed class YanShuAuthorizeAttribute : AuthorizeAttribute
    {

        public YanShuAuthorizeAttribute()
        {
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return base.AuthorizeCore(httpContext);
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated) return;
            var currentUrl = filterContext.RequestContext.HttpContext.Request.Url.AbsoluteUri;
            var returnUrl = "http://51yanshu.8866.org/Authorize";
            var url = RequestUrl.GetAuthorize(ConfigSetting.AppId, returnUrl.UrlEncode(), "snsapi_base", currentUrl.UrlEncode());
            filterContext.HttpContext.Response.Redirect(url);
        }
    }
}