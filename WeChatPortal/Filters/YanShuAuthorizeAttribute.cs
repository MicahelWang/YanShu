using System;
using System.Web;
using System.Web.Mvc;
using WeChatPortal.Constants;
using WeChatPortal.Utils;
using WeChatPortal.Utils.HttpUtility;
using UrlHelper = System.Web.Http.Routing.UrlHelper;

namespace WeChatPortal.Filters
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed class YanShuAuthorizeAttribute : AuthorizeAttribute
    {
        private static string domainUrl = string.Empty;
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

            var request = filterContext.RequestContext.HttpContext.Request;
            if (request.Url != null)
            {
                if (domainUrl==string.Empty)
                {
                    domainUrl = request.Url.Scheme+"://"+request.Url.Authority;
                }
                string userAgent = request.UserAgent;
                var currentUrl = request.Url.AbsoluteUri;
                string url;
                if (userAgent != null && userAgent.ToLower().Contains("micromessenger"))
                {
                    var returnUrl = domainUrl+"/Authorize";
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
}