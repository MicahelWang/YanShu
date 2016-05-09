using System.Xml.Serialization;

namespace WeChatPortal.Entities.XmlModels.Request
{
    [XmlRoot(ElementName = "xml")]
    public class RequestVideo : RequestBaseMessage
    {
        public string MediaId { get; set; }
        public string ThumbMediaId { get; set; }
    }
}