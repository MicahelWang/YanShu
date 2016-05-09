using System.Xml;
using System.Xml.Serialization;

namespace WeChatPortal.Entities.Data
{
    public class VoiceEntity
    {
        [XmlElement("MediaId")]
        public XmlCDataSection XmlMediaId
        {
            get { return new XmlDataDocument().CreateCDataSection(MediaId); }
            set { MediaId = value.Value; }
        }

        [XmlIgnore]
        public string MediaId { get; set; }
     
    }
}