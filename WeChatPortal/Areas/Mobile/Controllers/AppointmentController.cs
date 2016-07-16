using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeChatPortal.Entities.Data;
using WeChatPortal.Services;
using WeChatPortal.Utils.HttpUtility;

namespace WeChatPortal.Areas.Mobile.Controllers
{
    public class AppointmentController : MobileBaseController
    {
        private readonly MessageService _messageService = new MessageService();
        // GET: Mobile/Appointment
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Index(string phoneNum, string date)
        {
            var result = new ResponseEntity<object>
            {
                Success = true,
                Data = null
            };
            var appointmentDate = Convert.ToDateTime(date);
            var templateId = "CMk-nzNl_Zhkarcmn1FoYzobHxDe0387WPBrqkwcDS4";
            var data = new
            {
                first = new TemplateDataEntity("恭喜您，你的预约已经成功。", "#FF3030"),
                keyword1 = new TemplateDataEntity("投保行程预约", "#173177"),
                keyword2 = new TemplateDataEntity(appointmentDate.ToString("yyyy年MM月dd日"), "#FF3030"),
                remark = new TemplateDataEntity("如有疑问，请及时联系。", "#173177")
            };
            var openId = CurrentUser.OpenID;
            var entity = new TemplateMsgEntity<object>
            {
                template_id = templateId,
                touser = openId,
                url = "",
                data = data
            };
            _messageService.PushTemplateMessage(entity);
            return Json(result);
        }
    }

}
