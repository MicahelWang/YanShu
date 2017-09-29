using System;
using System.Web.Mvc;
using System.Web.Security;
using WeChatPortal.Models;
using WeChatPortal.Utils;

namespace WeChatPortal.Controllers
{
    public abstract class BaseController : Controller
    {
        private User _currentUser;
        protected BaseController()
        {


        }

        public User CurrentUser
        {
            get
            {
                _currentUser = new User();
                try
                {
                    var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                    if (cookie == null)
                    {
                        Log4NetHelper.WriteDebug("cookie 为 Null");
                        return _currentUser;
                    }
                    var ticket = FormsAuthentication.Decrypt(cookie.Value);
                    if (ticket != null)
                        _currentUser = ticket.UserData.DeserializeJson<User>();
                }
                catch (Exception ex)
                {
                    Log4NetHelper.WriteDebug("用户获取失败,Exception={" + ex.Message + "}");
                }
                return _currentUser;
            }
        }
    }
}