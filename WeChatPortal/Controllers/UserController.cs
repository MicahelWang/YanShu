using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WeChatPortal.Entities.Data;
using WeChatPortal.Services;

namespace WeChatPortal.Controllers
{
    public class UserController : ApiController
    {
        private readonly WxUserService _wxUserService;

        public UserController()
        {
            _wxUserService = new WxUserService();
        }

        public async Task<UserEntity> Get(string id = null)
        {
            return await _wxUserService.GetUsers(id);
        }

        [AcceptVerbs("Detail")]
        public async Task<UserDetailEntity> GetUser(string id)
        {
            return await _wxUserService.GetUser(id);
        }
    }
}
