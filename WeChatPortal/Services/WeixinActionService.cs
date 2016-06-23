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

        public async  Task<BaseMessage> HandleText(RequestText info)
        {

            BaseMessage response = new ResponseText(info)
            {
                Content = Msg
            };
            return await Task.FromResult(response);

        }

        public async  Task<BaseMessage> HandleImage(RequestImage info)
        {

            BaseMessage response = new ResponseText(info)
            {
                Content = Msg
            };
            return await Task.FromResult(response);

        }
        public async  Task<BaseMessage> HandleVoice(RequestVoice info)
        {

            BaseMessage response = new ResponseText(info)
            {
                Content = Msg
            };
            return await Task.FromResult(response);

        }

        public async  Task<BaseMessage> HandleVideo(RequestVideo info)
        {

            BaseMessage response = new ResponseText(info)
            {
                Content = Msg
            };
            return await Task.FromResult(response);
        }

        public async  Task<BaseMessage> HandleShortVideo(RequestVideo info)
        {

            BaseMessage response = new ResponseText(info)
            {
                Content = Msg
            };
            return await Task.FromResult(response);
        }

        public async  Task<BaseMessage> HandleLocation(RequestLocation info)
        {

            BaseMessage response = new ResponseText(info)
            {
                Content = Msg
            };
            return await Task.FromResult(response);
        }

        public async Task<BaseMessage> HandleLink(RequestLink info)
        {

            BaseMessage response = new ResponseText(info)
            {
                Content = Msg
            };
            return await Task.FromResult(response);
        }

        public async Task<BaseMessage> HandleEventClick(RequestEvent info)
        {
            BaseMessage response = null;
            EventType eventType;
            if (!Enum.TryParse(info.Event, true, out eventType)) return null;
            switch (eventType)
            {
                case EventType.Subscribe:
                    response = await _eventService.SubscribeEvent(info);
                    break;
                case EventType.Unsubscribe:
                    response = await _eventService.UnsubscribeEvent(info);
                    break;
                case EventType.Scan:
                    break;
                case EventType.Location:
                    break;
                case EventType.Click:
                    response = await _eventService.ClickEvent(info);
                    break;
                case EventType.View:
                    break;
                default:
                    break;
            }
            return await Task.FromResult(response);
        }
    }
}