using System;
using System.Xml;
using WeChatPortal.Constants.WeChat.Core.Constants;
using WeChatPortal.Entities.Data;
using WeChatPortal.Utils.WeChatEncrypt;

namespace WeChatPortal.Utils
{
    public static class WeChatXmlHelper
    {

        public static XmlDocument Execute(string context, RequesEntity request)
        {
            if (string.IsNullOrWhiteSpace(context))
                throw new ArgumentException("Argument is null or whitespace", nameof(context));
            var doc = new XmlDocument();
            doc.LoadXml(context);
            return Execute(doc, request);
        }


        public static XmlDocument Execute(XmlDocument doc, RequesEntity request)
        {
            if (ConfigSetting.Encrypt)
            {
                doc = EncryptDocument(doc, request);
            }
            return doc;
        }

        public static XmlDocument EncryptDocument(XmlDocument document, RequesEntity request)
        {
            if (document == null) throw new ArgumentNullException(nameof(document));
            var node = document.GetNodel("Encrypt");
            if (node == null) throw new Exception("找不到 Encrypt 节点");

            var utils = new WxBizMsgCrypt(ConfigSetting.Token, ConfigSetting.EncodingAesKey, ConfigSetting.AppId);
            //var content = 
            var doc = new XmlDocument();

            if (document.DocumentElement != null)
            {
                var encryptElement = document.DocumentElement["Encrypt"];
            }
            return doc;
        }

        private static XmlNode GetNodel(this XmlDocument document, string nodeName)
        {
            if (document == null) throw new ArgumentNullException(nameof(document));
            XmlElement root = document.DocumentElement;
            if (root == null) throw new ArgumentNullException(nameof(root));
            XmlNode node = root.SelectSingleNode(nodeName);
            return node;
        }

        public static MsgType GetMsgType(this XmlDocument document)
        {
            if (document == null) throw new ArgumentNullException(nameof(document));
            var node = document.GetNodel("MsgType");
            if (node == null) throw new Exception("找不到 MsgType 节点");
            var msgTypeName = node.InnerText;
            var msgType = MsgType.Text;
            if (Enum.TryParse(msgTypeName, true, out msgType))
            {
                return msgType;
            }
            return msgType;


        }

        public static EventType GetEventType(this XmlDocument document)
        {
            if (document == null) throw new ArgumentNullException(nameof(document));
            var node = document.GetNodel("Event");
            if (node == null) throw new Exception("找不到 Event 节点");
            var eventTypeName = node.InnerText;
            var eventType = EventType.Click;
            return Enum.TryParse(eventTypeName, true, out eventType) ? eventType : eventType;
        }
    }
}