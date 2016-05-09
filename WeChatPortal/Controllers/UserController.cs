using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeChatPortal.Entities.Data;
using WeChatPortal.Services;

namespace WeChatPortal.Controllers
{
    public class UserController : ApiController
    {
        private readonly UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        public UserEntity Get(string id = null)
        {
            return _userService.GetUsers(id);
        }

        [AcceptVerbs("Detail")]
        public UserDetailEntity GetUser(string id)
        {
            return _userService.GetUser(id);
        }
    }
}
