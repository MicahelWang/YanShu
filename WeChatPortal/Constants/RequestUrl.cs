namespace WeChatPortal.Constants
{
    public class RequestUrl
    {

        #region Authorize

        private const string AuthorizeUrl =
            "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope={2}&state={3}#wechat_redirect";

        public static string GetAuthorize(string appId,string returnUrl,string scope,string state= "STATE")
        {
            return string.Format(AuthorizeUrl, appId, returnUrl, scope,state);
        }

        private const string AuthorzeAccessTokenUrl =
           "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";

        public static string GetAuthorzeAccessToken(string appId, string secret, string code)
        {
            return string.Format(AuthorzeAccessTokenUrl, appId, secret, code);
        }

        private const string AuthorzeUserInfoUrl =
            "https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN";
        public static string GetAuthorzeUserInfo(string appId, string token)
        {
            return string.Format(AuthorzeUserInfoUrl, appId, token);
        }
        #endregion

        #region Base Token

       
        private const string TokenUrl =
            "https://api.weixin.qq.com/cgi-bin/token?grant_type={0}&appid={1}&secret={2}";
        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="appsecret"></param>
        /// <param name="grantType"></param>
        /// <returns></returns>
        public static string GetToken( string appid, string appsecret,string grantType= "client_credential")
        {
            return string.Format(TokenUrl, grantType, appid, appsecret);
        }
        #endregion

        #region User


        private const string UsersUrl =
            "https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}&nextOpenid={1}";

        public static string GetUsers(string token, string nextOpenid="")
        {
            return string.Format(UsersUrl, token, nextOpenid);
        }
        private const string UsersByOpenIdUrl =
            "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN";

        public static string GetUsersByOpenId(string token, string openid)
        {
            return string.Format(UsersByOpenIdUrl, token, openid);
        }
        #endregion

        #region Resources

      
        private const string UploadTempUrl =
            "https://api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}";
        /// <summary>
        /// 临时素材上传
        /// </summary>
        /// <param name="token"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string PostUploadTemp(string token, string type)
        {
            return string.Format(UploadTempUrl, token, type);
        }
        /// <summary>
        /// 新增永久图文素材
        /// </summary>
        private const string AddNewsUrl =
           "https://api.weixin.qq.com/cgi-bin/material/add_news?access_token={0}";

        public static string PostAddNews(string token)
        {
            return string.Format(AddNewsUrl, token);
        }

        /// <summary>
        /// 上传图文消息内的图片获取UR
        /// </summary>
        private const string UploadImageUrl =
           "https://api.weixin.qq.com/cgi-bin/media/uploadimg?access_token={0}";

        public static string PostUploadImage(string token)
        {
            return string.Format(UploadImageUrl, token);
        }


        /// <summary>
        /// 新增其他类型永久素材
        /// </summary>
        private const string UploadMaterialUrl =
           "https://api.weixin.qq.com/cgi-bin/material/add_material?access_token={0}";

        public static string PostUploadMaterialUrl(string token)
        {
            return string.Format(UploadMaterialUrl, token);
        }

        #endregion

        #region QR Code

        private const string CreateQrCodeUrl = "https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={0}";

        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string PostCreateQrCodeUrl(string token)
        {
            return string.Format(CreateQrCodeUrl, token);
        }

        private const string ShowQrCodeUrl = "https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket={0}";
        /// <summary>
        /// 获取QR Code 通过  ticket
        /// </summary>
        /// <param name="ticket"> 必须  UrlEncode</param>
        /// <returns></returns>
        public static string GetShowQrCodeUrl(string ticket)
        {
            return string.Format(ShowQrCodeUrl, ticket);
        }
        #endregion
    }
}