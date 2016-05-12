using System.Threading.Tasks;
using WeChatPortal.Constants;
using WeChatPortal.Entities.Data;
using WeChatPortal.Entities.WxResult;

namespace WeChatPortal.Services
{
    public class WxUserService : BaseService
    {
        public WxUserService() : base()
        {
        }
        public async Task<UserDetailResult> GetUser(string openId)
        {
            var url = RequestUrl.GetUsersByOpenId(this.Token, openId);
            return await GetJsonAsync<UserDetailResult>(url);
        }

        public async Task<UserResult> GetUsers(string nextOpenid)
        {
            var url = RequestUrl.GetUsers(this.Token, nextOpenid);
            return await GetJsonAsync<UserResult>(url);
        }


    }
}