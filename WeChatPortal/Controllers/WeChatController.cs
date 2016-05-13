using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Xml;
using WeChatPortal.Entities.XmlModels;
using WeChatPortal.Filters;
using WeChatPortal.Services;
using WeChatPortal.Utils;
using WeChatPortal.Utils.Mvc;

namespace WeChatPortal.Controllers
{
    [ApiActionFilter(false)]
    public class WeChatController : ApiController
    {
        private readonly WeChatService _chatService;
        public WeChatController()
        {
            _chatService = new WeChatService();
        }
        public HttpResponseMessage Get(string signature, string timestamp, string nonce, string echostr)
        {
            var token = ConfigSetting.Token;
            var flag = Helper.CheckSignature(token, signature, timestamp, nonce);
            var value = string.Empty;
            if (flag)
            {
                value = echostr;
            }
            HttpResponseMessage responseMessage =
               new HttpResponseMessage { Content = new StringContent(value, Encoding.GetEncoding("UTF-8"), "text/plain") };
            return responseMessage;

        }

        [HttpPost]
        public HttpResponseMessage Post()
        {
            //var request = new RequesEntity {signature = signature,timestamp = timestamp,nonce =nonce,echostr = echostr};
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(HttpContext.Current.Request.InputStream);
            var document = WeChatXmlHelper.Execute(xmlDoc, null);
            Log4NetHelper.WriteLog("request:\r\n" + document.ConvertToString());
            BaseMessage response = _chatService.Execute(document);
            Log4NetHelper.WriteLog("response：\r\n" + response.ToXml());
            return response.XmlResponse();
        }
    }
}
