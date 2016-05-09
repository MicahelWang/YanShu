using System.Xml.Serialization;

namespace WeChatPortal.Entities.XmlModels.Request
{
    [XmlRoot(ElementName = "xml")]
    public class RequestLocation : RequestBaseMessage
    {
        public string MediaId { get; set; }
        public double Location_X { get; set; }
        public double Location_Y { get; set; }
        public int Scale { get; set; }
        public string Label { get; set; }
    }
}