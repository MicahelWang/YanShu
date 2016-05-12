using WeChatPortal.Constants;
using WeChatPortal.Entities.Data;
using WeChatPortal.Entities.WxResult;
using WeChatPortal.Utils;

namespace WeChatPortal.Services
{
    public class AuthorizeService:BaseService
    {
        public AuthorizeAccessTokenResult GetAuthorizeEntity(string code)
        {
            var url = RequestUrl.GetAuthorzeAccessToken(ConfigSetting.AppId, ConfigSetting.AppSecret, code);
            return GetJson<AuthorizeAccessTokenResult>(url);
        }
    }
}