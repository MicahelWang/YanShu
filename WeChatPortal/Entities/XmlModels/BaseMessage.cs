using System;
using System.Xml.Serialization;
using WeChatPortal.Entities.XmlModels.Response;
using WeChatPortal.Utils;

namespace WeChatPortal.Entities.XmlModels
{
    /// <summary>
    /// 基础消息内容
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    [Serializable]
    [XmlInclude(typeof(ResponseNews))]
    [XmlInclude(typeof(ResponseImage))]
    [XmlInclude(typeof(ResponseMusic))]
    [XmlInclude(typeof(ResponseText))]
    [XmlInclude(typeof(ResponseVideo))]
    [XmlInclude(typeof(ResponseVoice))]
    public class BaseMessage
    {
       
        /// <summary>
        /// 初始化一些内容，如创建时间为整形，
        /// </summary>
        public BaseMessage()
        {
            this.CreateTime = DateTime.Now.ConvertToInt();
        }

        /// <summary>
        /// 开发者微信号
        /// </summary>
        //[XmlElement("ToUserName")]
        //public XmlCDataSection XmlToUserName
        //{
        //    get { return new XmlDataDocument().CreateCDataSection(ToUserName); }
        //    set { ToUserName = value.Value; }
        //}

        //[XmlIgnore]
        public string ToUserName { get; set; }


        //[XmlElement("FromUserName")]
        //public XmlCDataSection XmlFromUserName
        //{
        //    get { return new XmlDataDocument().CreateCDataSection(FromUserName); }
        //    set { FromUserName = value.Value; }
        //}
        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        //[XmlIgnore]
        public string FromUserName { get; set; }

        /// <summary>
        /// 消息创建时间 （整型）
        /// </summary>
        public long CreateTime { get; set; }

        //[XmlElement("MsgType")]
        //public XmlCDataSection XmlMsgType
        //{
        //    get { return new XmlDataDocument().CreateCDataSection(MsgType); }
        //    set { MsgType = value.Value; }
        //}
        /// <summary>
        /// 消息类型
        /// </summary>
        //[XmlIgnore]
        public string MsgType { get; set; }

        //public virtual string ToXml()
        //{
        //    this.CreateTime = DateTime.Now.ConvertToInt();//重新更新
        //    return this.SerializerToXml();
        //}

    }
}