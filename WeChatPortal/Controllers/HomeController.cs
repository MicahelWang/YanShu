using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WeChatPortal.Filters;
using WeChatPortal.Models;
using WeChatPortal.Services;
using WeChatPortal.Utils;

namespace WeChatPortal.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [AllowAnonymous]
        public async Task<ActionResult> Login(string returnUrl,string openId="")
        {
            if (openId!="")
            {
                UserService userService = new UserService();
                var user = await userService.GetUser(openId, true);
            }
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            //if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            //{
            //    return RedirectToLocal(returnUrl);
            //}

            ////// 如果我们进行到这一步时某个地方出错，则重新显示表单
            ////ModelState.AddModelError("", "提供的用户名或密码不正确。");
            //return View(model);

            User user = new User
            {
                OpenID = string.Empty,
                ID = 1010,
                Name = model.UserName
            };
            var userData = user.ToJson();
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.Name, DateTime.Now, DateTime.Now.AddHours(12), false, userData);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));//加密身份信息，保存至Cookie 
            Response.Cookies.Add(cookie);
            return Redirect(returnUrl);
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            //WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
