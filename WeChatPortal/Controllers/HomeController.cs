using System.Web.Mvc;
using WeChatPortal.Filters;

namespace WeChatPortal.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


    }
}
