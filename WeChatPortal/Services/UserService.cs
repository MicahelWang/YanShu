using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChatPortal.Constants;
using WeChatPortal.Entities.Data;
using WeChatPortal.Models;

namespace WeChatPortal.Services
{
    public class UserService : BaseService
    {
        private readonly InsuranceDb _db = new InsuranceDb();
        public UserService() : base()
        {
        }
        public async Task<User> AddUser(User entity)
        {
            _db.User.Add(entity);
            _db.SaveChanges();
            return await Task.FromResult(entity);
        }

        protected async Task<User> AddUser(UserDetailEntity entity)
        {
            var user = new User
            {
                OpenID = entity.openid,
                Email = "",
                Gender = entity.sex,
                Name = entity.nickname,
                UpdatedDate = DateTime.Now,
            };
            user = await AddUser(user);
            return user;
        }
        /// <summary>
        /// 获取用户，如果是微信  没有会新增
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="isWx"></param>
        /// <returns></returns>
        public async Task<User> GetUser(string openId, bool isWx = false)
        {
            var result = _db.User.FirstOrDefault(m => m.OpenID == openId);
            if (!isWx) return await Task.FromResult(result);
            if (result != null) return await Task.FromResult(result);
            var wxUserService = new WxUserService();
            var wxUser = await wxUserService.GetUser(openId);
            return await AddUser(wxUser);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var result = _db.User;
            return await Task.FromResult(result);
        }

    }
}