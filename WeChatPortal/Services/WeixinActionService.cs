using System;
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
        private const string Msg = "我不明白您在做做什么.";
        public WeixinActionService()
        {
            _eventService = new EventService();
        }

        public BaseMessage HandleText(RequestText info)
        {

            var response = new ResponseText(info)
            {
                Content = Msg
            };
            return response;

        }

        public BaseMessage HandleImage(RequestImage info)
        {

            var response = new ResponseText(info)
            {
                Content = Msg
            };
            return response;

        }
        public BaseMessage HandleVoice(RequestVoice info)
        {

            var response = new ResponseText(info)
            {
                Content = Msg
            };
            return response;

        }

        public BaseMessage HandleVideo(RequestVideo info)
        {

            var response = new ResponseText(info)
            {
                Content = Msg
            };
            return response;
        }

        public BaseMessage HandleShortVideo(RequestVideo info)
        {

            var response = new ResponseText(info)
            {
                Content = Msg
            };
            return response;
        }

        public BaseMessage HandleLocation(RequestLocation info)
        {

            var response = new ResponseText(info)
            {
                Content = Msg
            };
            return response;
        }

        public BaseMessage HandleLink(RequestLink info)
        {

            var response = new ResponseText(info)
            {
                Content = Msg
            };
            return response;
        }

        public BaseMessage HandleEventClick(RequestEvent info)
        {

            EventType eventType = (EventType)Enum.Parse(typeof(EventType), info.Event, true);
            switch (eventType)
            {
                case EventType.Subscribe:
                    break;
                case EventType.Unsubscribe:
                    break;
                case EventType.Scan:
                    break;
                case EventType.Location:
                    break;
                case EventType.Click:
                    return _eventService.ClickEvent(info);
                    break;
                case EventType.View:
                    break;
                default:
                    break;
            }
            var response = new ResponseText(info)
            {
                Content = Msg
            };

            return response;
        }
    }
}