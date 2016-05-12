using System.Threading.Tasks;
using WeChatPortal.Constants;
using WeChatPortal.Entities.Data;

namespace WeChatPortal.Services
{
    public class WxUserService : BaseService
    {
        public WxUserService() : base()
        {
        }
        public async Task<UserDetailEntity> GetUser(string openId)
        {
            var url = RequestUrl.GetUsersByOpenId(this.Token, openId);
            return await GetJsonAsync<UserDetailEntity>(url);
        }

        public async Task<UserEntity> GetUsers(string nextOpenid)
        {
            var url = RequestUrl.GetUsers(this.Token, nextOpenid);
            return await GetJsonAsync<UserEntity>(url);
        }


    }
}