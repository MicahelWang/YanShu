using WeChatPortal.Entities.XmlModels;
using WeChatPortal.Entities.XmlModels.Request;

namespace WeChatPortal.Services
{
    public class EventService
    {
        readonly ContextService _contextService = new ContextService();
        public BaseMessage ClickEvent(RequestEvent request)
        {
           var response= _contextService.GetResponseByEvent(request);
            return response;
        }
    }
}