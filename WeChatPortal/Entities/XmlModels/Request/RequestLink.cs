using System.Xml.Serialization;

namespace WeChatPortal.Entities.XmlModels.Request
{
    [XmlRoot(ElementName = "xml")]
    public class RequestLink : RequestBaseMessage
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}