using System;
using System.Xml;
using WeChatPortal.Constants.WeChat.Core.Constants;
using WeChatPortal.Entities.XmlModels;
using WeChatPortal.Entities.XmlModels.Request;
using WeChatPortal.Utils;

namespace WeChatPortal.Services
{
    public class WeChatService
    {
        private readonly WeixinActionService _weixinAction;

        public WeChatService()
        {
            _weixinAction = new WeixinActionService();
        }
        public BaseMessage Execute(XmlDocument document)
        {
            BaseMessage response;
            MsgType msgType = document.GetMsgType();
            switch (msgType)
            {
                case MsgType.Text:
                    response = _weixinAction.HandleText(document.XmlDeserializer<RequestText>());
                    break;
                case MsgType.Image:
                    response = _weixinAction.HandleImage(document.XmlDeserializer<RequestImage>());
                    break;
                case MsgType.Voice:
                    response = _weixinAction.HandleVoice(document.XmlDeserializer<RequestVoice>());
                    break;
                case MsgType.Video:
                    response = _weixinAction.HandleVideo(document.XmlDeserializer<RequestVideo>());
                    break;
                case MsgType.ShortVideo:
                    response = _weixinAction.HandleShortVideo(document.XmlDeserializer<RequestVideo>());
                    break;
                case MsgType.Location:
                    response = _weixinAction.HandleLocation(document.XmlDeserializer<RequestLocation>());
                    break;
                case MsgType.Link:
                    response = _weixinAction.HandleLink(document.XmlDeserializer<RequestLink>());
                    break;
                case MsgType.Event:
                    response = _weixinAction.HandleEventClick(document.XmlDeserializer<RequestEvent>());
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return response;
        }
    }
}