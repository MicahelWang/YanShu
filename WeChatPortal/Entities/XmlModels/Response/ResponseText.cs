using System;
using System.Xml.Serialization;
using WeChat.Core.XmlModels;
using WeChatPortal.Constants.WeChat.Core.Constants;

namespace WeChatPortal.Entities.XmlModels.Response
{
    /// <summary>
    /// 回复文本消息
    /// </summary>
    [XmlRoot(ElementName = "xml", Namespace = "")]
    [Serializable]
    public class ResponseText : BaseMessage
    {
        public ResponseText()
        {
            MsgType = ResponseType.Text.ToString().ToLower();
        }

        public ResponseText(BaseMessage info) : this()
        {
            this.FromUserName = info.ToUserName;
            this.ToUserName = info.FromUserName;
        }

        public ResponseText(BaseMessage info,string content) : this(info)
        {
            this.Content = content;
        }
       
        public string Content { get; set; }
    }
}