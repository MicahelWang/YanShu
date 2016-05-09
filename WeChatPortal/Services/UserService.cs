using WeChatPortal.Constants;
using WeChatPortal.Entities.Data;

namespace WeChatPortal.Services
{
    public class UserService : BaseService
    {
        public UserService() : base()
        {
        }
        public string AddUser()
        {
            throw new System.NotImplementedException();
        }

        public UserDetailEntity GetUser(string openId)
        {
            var url = RequestUrl.GetUsersByOpenId(this.Token, openId);
            return GetJson<UserDetailEntity>(url);
        }

        public UserEntity GetUsers(string nextOpenid)
        {
            var url = RequestUrl.GetUsers(this.Token, nextOpenid);
            return GetJson<UserEntity>(url);
        }


    }
}