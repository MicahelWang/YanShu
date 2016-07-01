using System.Web.Mvc;

namespace WeChatPortal.Areas.Mobile.Controllers
{
    public class CalculatorController : MobileBaseController
    {
        // GET: Mobile/Calculator
        public ActionResult Index()
        {
            return View();
        }
    }
}