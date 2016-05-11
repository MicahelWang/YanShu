using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeChatPortal.Filters;

namespace WeChatPortal.Areas.Mobile.Controllers
{
    [YanShuAuthorize]
    public class PlanController : Controller
    {
        // GET: Mobile/Plan
        public ActionResult Index()
        {
            return View();
        }
    }
}