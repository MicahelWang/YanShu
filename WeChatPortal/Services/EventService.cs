using System.Threading.Tasks;
using WeChatPortal.Entities.XmlModels;
using WeChatPortal.Entities.XmlModels.Request;
using WeChatPortal.Entities.XmlModels.Response;

namespace WeChatPortal.Services
{
    public class EventService
    {
        private readonly ContextService _contextService;
        private readonly UserService _userService;
        public EventService()
        {
            _contextService = new ContextService();
            _userService = new UserService();
        }

        public async  Task<BaseMessage> ClickEvent(RequestEvent request)
        {
            var response = _contextService.GetResponseByEvent(request);
            return await Task.FromResult(response);
        }

        public async  Task<BaseMessage> SubscribeEvent(RequestEvent request)
        {
            BaseMessage response = new ResponseText(request)
            {
                Content = "欢迎订阅燕枢宝。"
            };
           
            var recommendCode =string.Empty;
            if (!string.IsNullOrWhiteSpace(request.EventKey))
            {
                var array= request.EventKey.Split('|');
                if (array[0].ToLower().Contains("register"))
                {
                    recommendCode = array[1];
                }
            }
            _userService.Subscribe(request.FromUserName, recommendCode);
            return await Task.FromResult(response);
        }
        public async  Task<BaseMessage> UnsubscribeEvent(RequestEvent request)
        {
            BaseMessage response = new ResponseText(request)
            {
                Content = ""
            };
            _userService.Unsubscribe(request.FromUserName);
            return await Task.FromResult(response);
        }
        
    }
}