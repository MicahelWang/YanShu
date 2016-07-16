using System.Web.Mvc;
using WeChatPortal.Filters;

namespace WeChatPortal.Areas.Mobile.Controllers
{
    [YanShuAuthorize]
    public class CalculatorController : MobileBaseController
    {
        // GET: Mobile/Calculator
        public ActionResult Index()
        {
            return View();
        }
    }
}