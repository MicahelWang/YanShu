using System.Web.Mvc;
using WeChatPortal.Filters;

namespace WeChatPortal.Areas.Mobile.Controllers
{
    [YanShuAuthorize]
    public class PlanController : MobileBaseController
    {
        // GET: Mobile/Plan
        public ActionResult Index()
        {
            return View();
        }
    }
}