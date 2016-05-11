using WeChatPortal.Constants;
using WeChatPortal.Entities.Data;
using WeChatPortal.Utils;

namespace WeChatPortal.Services
{
    public class AuthorizeService:BaseService
    {
        public AuthorizeAccessTokenEntity GetAuthorizeEntity(string code)
        {
            var url = RequestUrl.GetAuthorzeAccessToken(ConfigSetting.AppId, ConfigSetting.AppSecret, code);
            return GetJson<AuthorizeAccessTokenEntity>(url);
        }
    }
}