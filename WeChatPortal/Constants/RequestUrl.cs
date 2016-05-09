namespace WeChatPortal.Constants
{
    public class RequestUrl
    {
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
         
        private const string UploadTempUrl =
            "https://api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}";
        /// <summary>
        /// 零食素材上传
        /// </summary>
        /// <param name="token"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string PostUploadTemp(string token, string type)
        {
            return string.Format(UploadTempUrl, token, token, type);
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

    }
}