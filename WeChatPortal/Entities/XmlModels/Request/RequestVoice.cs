using System.Xml.Serialization;

namespace WeChatPortal.Entities.XmlModels.Request
{
    [XmlRoot(ElementName = "xml")]
    public class RequestVoice : RequestBaseMessage
    {
        public string MediaId { get; set; }
        public string Format { get; set; }

        public string Recognition { get; set; }
    }
}