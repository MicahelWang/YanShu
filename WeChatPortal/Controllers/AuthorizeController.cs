using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WeChatPortal.Entities.Data;
using WeChatPortal.Filters;
using WeChatPortal.Models;
using WeChatPortal.Services;
using WeChatPortal.Utils;
using WeChatPortal.Utils.HttpUtility;

namespace WeChatPortal.Controllers
{
    [CustomActionFilter]
    public class AuthorizeController : Controller
    {

        readonly AuthorizeService _service = new AuthorizeService();
        // GET: Authorize
        public ActionResult Index(string code, string state)
        {
            var entity = _service.GetAuthorizeEntity(code);
            Log4NetHelper.WriteLog("Authorize result=" + entity.ToJson());

            ////保存身份信息，参数说明可以看提示 
            User user = new User
            {
                OpenID = entity.openid,
                ID = 1010,
                Name = "Michael"
            };
            var userData = user.ToJson();
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.Name, DateTime.Now, DateTime.Now.AddHours(12), false, userData);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));//加密身份信息，保存至Cookie 
            Response.Cookies.Add(cookie);
            return Redirect(state.UrlDecode());
        }


    }

}