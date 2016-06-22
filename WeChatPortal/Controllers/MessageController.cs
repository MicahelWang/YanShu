using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WeChatPortal.Constants.WeChat.Core.Constants;
using WeChatPortal.Entities.WxResult;
using WeChatPortal.Services;

namespace WeChatPortal.Controllers
{
    public class MessageController : ApiController
    {
        private readonly MessageService _messageService = new MessageService();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="messageType"></param>
        /// <returns></returns>
        public async Task<string> Post(string id, MessageType messageType)
        {
            return await _messageService.PushMesaage(id, messageType);
        }
    }
}
