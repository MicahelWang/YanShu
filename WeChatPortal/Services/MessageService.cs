using System;
using System.Linq;
using System.Threading.Tasks;
using WeChatPortal.Constants;
using WeChatPortal.Constants.WeChat.Core.Constants;
using WeChatPortal.Entities.Data;
using WeChatPortal.Entities.WxResult;

namespace WeChatPortal.Services
{
    public class MessageService : BaseService
    {
        public async Task<string> PushTemplateMessage<T>(TemplateMsgEntity<T> entity) where T : class, new()
        {
            var url = RequestUrl.PostPushTemplateMessageUrl(this.Token);

            var result = await PostSendJson<PushTemplateMessageResult>(url, entity);
            return result.msgid;
        }

        public async Task<string> PushMesaage(string id, MessageType messageType)
        {

            var userService = new UserService();
            var userId = 2;
            if (messageType == MessageType.Notification)
                int.TryParse(id, out userId);
            var user = userService.GetUsers().FirstOrDefault(m => m.ID == userId);
            string templateId;
            object data = new object();
            switch (messageType)
            {
                case MessageType.BookingSuccess:
                    templateId = "CMk-nzNl_Zhkarcmn1FoYzobHxDe0387WPBrqkwcDS4";
                    data = new
                    {
                        first = new TemplateDataEntity("恭喜您，你的预约已经成功。", "#FF3030"),
                        keyword1 = new TemplateDataEntity("投保行程预约", "#173177"),
                        keyword2 = new TemplateDataEntity(DateTime.Now.AddHours(12).ToString("yyyy年MM月dd日 HH:mm"), "#FF3030"),
                        remark = new TemplateDataEntity("如有疑问，请及时联系。", "#173177")
                    };
                    break;
                case MessageType.PlanResult:
                    templateId = "HsIbqfQOT_f-jP-oTNR3eogt6GYJ2gr0YW8g5JyXRZA";
                    break;
                case MessageType.Notification:
                    templateId = "T4bmwPElbKwe1ZaWUG0BfprnBqY4NjOoIC-q3x8fsSA";
                    data = new
                    {
                        first = new TemplateDataEntity(user?.Name+"您好，您已订阅成功。", "#FF3030"),
                        keyword1 = new TemplateDataEntity("燕枢宝服务号", "#173177"),
                        keyword2 = new TemplateDataEntity("永久", "#173177"),
                        keyword3 = new TemplateDataEntity(DateTime.Now.ToString("yyyy年MM月dd日 HH:mm"), "#FF3030"),
                        remark = new TemplateDataEntity("感谢您的订阅，祝您生活愉快！如有疑问，请联系在线客服！谢谢！", "#173177")
                    };
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(messageType), messageType, null);
            }
            var openId = user?.OpenID;
            var entity = new TemplateMsgEntity<object>
            {
                template_id = templateId,
                touser = openId,
                url = "http://www.baidu.com/" + id,
                data = data
            };
            return await PushTemplateMessage(entity);
        }
    }
}