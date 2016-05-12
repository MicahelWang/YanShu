namespace WeChatPortal.Entities.WxResult
{
    public class UserResult
    {

        /// <summary>
        /// 
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public UserDataResult data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string next_openid { get; set; }

    }
}