using System;
using System.Web.Mvc;
using System.Web.Security;
using WeChatPortal.Models;
using WeChatPortal.Utils;

namespace WeChatPortal.Controllers
{
    public abstract class BaseController: Controller
    {
        protected readonly User CurrentUser;

        protected BaseController()
        {
            try
            {
                var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                CurrentUser = ticket.UserData.DeserializeJson<User>();
            }
            catch (Exception)
            {
                CurrentUser = new User();
            }
           
        }
    }
}