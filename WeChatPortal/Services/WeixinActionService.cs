using System;
using System.Threading.Tasks;
using WeChat.Core.XmlModels;
using WeChatPortal.Constants.WeChat.Core.Constants;
using WeChatPortal.Entities.XmlModels;
using WeChatPortal.Entities.XmlModels.Request;
using WeChatPortal.Entities.XmlModels.Response;

namespace WeChatPortal.Services
{
    public class WeixinActionService
    {
        private readonly EventService _eventService;
        private const string Msg = "我不明白您在做什么.";
        public WeixinActionService()
        {
            _eventService = new EventService();
        }

        public Task<BaseMessage> HandleText(RequestText info)
        {

            BaseMessage response = new ResponseText(info)
            {
                Content = Msg
            };
            return Task.FromResult(response);

        }

        public Task<BaseMessage> HandleImage(RequestImage info)
        {

            BaseMessage response = new ResponseText(info)
            {
                Content = Msg
            };
            return Task.FromResult(response); 

        }
        public Task<BaseMessage> HandleVoice(RequestVoice info)
        {

            BaseMessage response = new ResponseText(info)
            {
                Content = Msg
            };
            return Task.FromResult(response); 

        }

        public Task<BaseMessage> HandleVideo(RequestVideo info)
        {

            BaseMessage response = new ResponseText(info)
            {
                Content = Msg
            };
            return Task.FromResult(response);
        }

        public Task<BaseMessage> HandleShortVideo(RequestVideo info)
        {

            BaseMessage response = new ResponseText(info)
            {
                Content = Msg
            };
            return Task.FromResult(response);
        }

        public Task<BaseMessage> HandleLocation(RequestLocation info)
        {

            BaseMessage response = new ResponseText(info)
            {
                Content = Msg
            };
            return Task.FromResult(response);
        }

        public Task<BaseMessage> HandleLink(RequestLink info)
        {

            BaseMessage response = new ResponseText(info)
            {
                Content = Msg
            };
            return Task.FromResult(response);
        }

        public Task<BaseMessage> HandleEventClick(RequestEvent info)
        {
            Task<BaseMessage> response = null;
            EventType eventType = (EventType)Enum.Parse(typeof(EventType), info.Event, true);
            switch (eventType)
            {
                case EventType.Subscribe:
                    response = _eventService.SubscribeEvent(info);
                    break;
                case EventType.Unsubscribe:
                    response = _eventService.UnsubscribeEvent(info);
                    break;
                case EventType.Scan:
                    break;
                case EventType.Location:
                    break;
                case EventType.Click:
                    response= _eventService.ClickEvent(info);
                    break;
                case EventType.View:
                    break;
                default:
                    break;
            }
            if (response != null) return response;
            BaseMessage msg = (new ResponseText(info) {Content = Msg});
            response = Task.FromResult(msg);
            return response;
        }
    }
}