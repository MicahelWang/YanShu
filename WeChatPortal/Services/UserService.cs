

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChatPortal.Constants;
using WeChatPortal.Entities.WxResult;
using WeChatPortal.Models;
using WeChatPortal.Utils.Caching;

namespace WeChatPortal.Services
{
    public class UserService : BaseService
    {
        private List<User> Users
            => CacheManager.Get(CacheKey.Users,GetUsers);

        private readonly InsuranceDb _db = new InsuranceDb();

        public async Task<User> AddUser(User entity)
        {
            if (!_db.User.Any(m => m.OpenID == entity.OpenID))
            {
                _db.User.Add(entity);
                CacheManager.Remove(CacheKey.Users);
                _db.SaveChanges();
            }

            return await Task.FromResult(entity);
        }

        protected async Task<User> AddUser(UserDetailResult entity, int? parentId = null)
        {
            var user = new User
            {
                OpenID = entity.openid,
                Email = "",
                Gender = entity.sex,
                Name = entity.nickname,
                UpdatedDate = DateTime.Now,
                ParentID = parentId
            };
            user = await AddUser(user);
            return user;
        }


        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public async Task<User> GetUser(string openId)
        {
            var result = Users.FirstOrDefault(m => m.OpenID == openId);
            if (result == null)
            {
                Subscribe(openId, "0");
            }
            return await Task.FromResult(result);
        }
        public void Unsubscribe(string openId)
        {
            Delete(openId);
        }

        protected void Delete(string openId)
        {
            Task.Run(() =>
            {
                var entity = _db.User.FirstOrDefault(m => m.OpenID == openId);
                if (entity == null)
                {
                    return; ;
                }
                entity.Email = "123";
                CacheManager.Remove(CacheKey.Users);
                _db.SaveChanges();
            });
        }

        public void Subscribe(string openId, string recommendCode)
        {
            Task.Run(async () =>
            {
                int arg;
                if (!int.TryParse(recommendCode, out arg))
                {
                    arg = 0;
                }
                var result = Users.FirstOrDefault(m => m.OpenID == openId);

                if (result == null)
                {
                    var wxUserService = new WxUserService();
                    var wxUser = await wxUserService.GetUser(openId);
                    int? parentId = null;
                    if (arg != 0)
                    {
                        parentId = arg;
                    }
                    await AddUser(wxUser, parentId);
                }
            });
        }

        public List<User> GetUsers()
        {
            var result = _db.User.ToList();
            return result;
        }

    }
}