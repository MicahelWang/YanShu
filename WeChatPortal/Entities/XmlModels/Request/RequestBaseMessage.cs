using System.Xml.Serialization;
using WeChat.Core.XmlModels;

namespace WeChatPortal.Entities.XmlModels.Request
{
    [XmlRoot(ElementName = "xml")]
    public class RequestBaseMessage: BaseMessage
    {
        public long MsgId { get; set; }
    }
}