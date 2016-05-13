using System.Threading.Tasks;
using WeChatPortal.Constants;
using WeChatPortal.Entities.WxResult;

namespace WeChatPortal.Services
{
    public class WxUserService : BaseService
    {
        public async Task<UserDetailResult> GetUser(string openId)
        {
            var url = RequestUrl.GetUsersByOpenId(Token, openId);
            return await GetJsonAsync<UserDetailResult>(url);
        }

        public async Task<UserResult> GetUsers(string nextOpenid)
        {
            var url = RequestUrl.GetUsers(Token, nextOpenid);
            return await GetJsonAsync<UserResult>(url);
        }


    }
}