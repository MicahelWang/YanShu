using System.Xml.Serialization;

namespace WeChatPortal.Entities.Data
{
    [XmlRoot(ElementName = "xml")]
    public class ResponseEntity<T>
    {

        public bool Success { get; set; }
        public string ErrorCode { get; set; }

        public string ErrorMsg { get; set; }

        public T Data { get; set; }
    }
}