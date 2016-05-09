using System.Collections.Generic;
using System.Xml.Serialization;
using WeChat.Core.XmlModels;
using WeChatPortal.Constants.WeChat.Core.Constants;
using WeChatPortal.Entities.Data;

namespace WeChatPortal.Entities.XmlModels.Response
{
    /// <summary>
    /// �ظ�ͼ����Ϣ
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class ResponseNews : BaseMessage
    {
        public ResponseNews()
        {
            MsgType = ResponseType.News.ToString().ToLower();

            this.Articles = new List<ArticleEntity>();
        }
        public ResponseNews(BaseMessage info) : this()
        {
            this.FromUserName = info.ToUserName;
            this.ToUserName = info.FromUserName;
        }

        /// <summary>
        /// ͼ����Ϣ����������Ϊ10������
        /// </summary>
        public int ArticleCount
        {
            get
            {
                return this.Articles.Count;
            }
            set
            {
                ;//�����������ų���XML����
            }
        }

        /// <summary>
        /// ͼ���б���
        /// ����ͼ����Ϣ��Ϣ��Ĭ�ϵ�һ��itemΪ��ͼ,ע�⣬���ͼ��������10���򽫻�����Ӧ
        /// </summary>
        [XmlArrayItem("item")]
        public List<ArticleEntity> Articles { get; set; }

        //public override string ToXml()
        //{
        //    this.CreateTime = DateTime.Now.ConvertToInt();//���¸���
        //    return this.SerializerToXml();
        //}

    }
}