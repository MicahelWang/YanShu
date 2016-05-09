using System.Xml.Serialization;

namespace WeChat.Core.XmlModels
{
    [XmlRoot(ElementName = "xml")]
    public class EncryptMessage
    {
        public string ToUserName { get; set; }
        public string Encrypt { get; set; }
    }
}