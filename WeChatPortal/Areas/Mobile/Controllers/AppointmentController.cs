using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeChatPortal.Areas.Mobile.Controllers
{
    public class AppointmentController : MobileBaseController
    {
        // GET: Mobile/Appointment
        public ActionResult Index()
        {
            return View();
        }
    }

}
