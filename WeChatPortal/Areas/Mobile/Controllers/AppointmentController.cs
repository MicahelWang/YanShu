using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WeChatPortal.Constants.WeChat.Core.Constants;
using WeChatPortal.Entities.Data;
using WeChatPortal.Filters;
using WeChatPortal.Models;
using WeChatPortal.Services;
using WeChatPortal.Utils.HttpUtility;

namespace WeChatPortal.Areas.Mobile.Controllers
{
    [YanShuAuthorize]
    public class AppointmentController : MobileBaseController
    {
        private readonly MessageService _messageService = new MessageService();
        private readonly AppointmentService _appointmentService = new AppointmentService();
        // GET: Mobile/Appointment
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Index(string phoneNum, string date)
        {
            var result = new ResponseEntity<object>
            {
                Success = true,
                Data = null
            };
            var appointmentDate = Convert.ToDateTime(date);
            var entity = new Appointment
            {
                AppointmentDate = appointmentDate,
                PhoneNum = phoneNum,
                IsDelete = false,
                CreateTime = DateTime.Now,
                Status = 1,
                UserId = CurrentUser.ID
            };
            int id = _appointmentService.Add(entity);
            //var templateId = "CMk-nzNl_Zhkarcmn1FoYzobHxDe0387WPBrqkwcDS4";
            //var data = new
            //{
            //    first = new TemplateDataEntity("恭喜您，你的预约已经成功。", "#FF3030"),
            //    keyword1 = new TemplateDataEntity("投保行程预约", "#173177"),
            //    keyword2 = new TemplateDataEntity(appointmentDate.ToString("yyyy年MM月dd日"), "#FF3030"),
            //    remark = new TemplateDataEntity("如有疑问，请及时联系。", "#173177")
            //};
            //var openId = CurrentUser.OpenID;
            //var entity = new TemplateMsgEntity<object>
            //{
            //    template_id = templateId,
            //    touser = openId,
            //    url = "https://www.baidu.com/",
            //    data = data
            //};
            await _messageService.PushMesaage(id,MessageType.AppointmentSuccess);
            return Json(result);
        }
    }

}
