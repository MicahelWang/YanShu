using System;
using System.Threading.Tasks;
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
        readonly UserService _userService = new UserService();
        readonly WxUserService _wxUserService = new WxUserService();
        // GET: Authorize
        public async Task<ActionResult> Index(string code, string state)
        {
            var entity = _service.GetAuthorizeEntity(code);
            Log4NetHelper.WriteDebug("Authorize result=" + entity.ToJson());
            var user =await _userService.GetUser(entity.openid,true);
            var userData = user.ToJson();
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.Name, DateTime.Now, DateTime.Now.AddMinutes(30), false, userData);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));//加密身份信息，保存至Cookie 
            Response.Cookies.Add(cookie);
            return Redirect(state.UrlDecode());
        }


    }

}