using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeChatPortal.Constants;
using WeChatPortal.Constants.WeChat.Core.Constants;
using WeChatPortal.Entities.WxResult;
using WeChatPortal.Utils;
using WeChatPortal.Utils.Caching;
using WeChatPortal.Utils.Helpers;
using WeChatPortal.Utils.HttpUtility;

namespace WeChatPortal.Services
{
    public class BaseService
    {

        public virtual void RequestCallBack(string returnText)
        {
            //可能发生错误
            var errorResult = returnText.DeserializeJson<WxJsonResult>();
            if (errorResult.errcode == (int)ReturnCode.请求成功)
            {
                return;
            }
            else if (errorResult.errcode == (int)ReturnCode.不合法的凭证类型)
            {
                CacheManager.Remove(CacheKey.AccessToken);
            }
            var msg = $"微信Post请求发生错误！错误代码：{errorResult.errcode}，说明：{errorResult.errmsg}";
            //发生错误
            throw new SimpleException(100000, msg);
        }

        protected async Task<T> GetJsonAsync<T>(string url)
        {
            return await Get.GetJsonAsync<T>(url, RequestCallBack);
        }

        protected async Task<T> PostSendJson<T>(string url, object data)
        {
            return await CommonJsonSend.SendAsync<T>(string.Empty, url, data, RequestCallBack);
        }

        protected T GetJson<T>(string url)
        {
            return Get.GetJson<T>(url, RequestCallBack);
        }
        protected T PostJson<T>(string url)
        {
            return Post.PostGetJson<T>(url, RequestCallBack);
        }

        protected T PosForm<T>(string url,object data)
        {
            var formData =
                data.AsDictionary() ;
            return Post.PostGetJson<T>(url, null, formData);
        }

        protected static ICacheManager CacheManager;
        public BaseService(ICacheManager cacheManager)
        {
            CacheManager = cacheManager;
        }
        public BaseService()
        {
            CacheManager = new CacheManager();
        }
        private string GetToken()
        {
            var url = RequestUrl.GetToken(ConfigSetting.AppId, ConfigSetting.AppSecret);
            var obj = GetJson<AccessTokenResult>(url);
            return obj.access_token;
        }
        protected string Token => CacheManager.Get(CacheKey.AccessToken, GetToken, DateTime.Now.AddSeconds(7200), TimeSpan.Zero);
    }
}