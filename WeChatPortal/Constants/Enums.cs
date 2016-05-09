namespace WeChatPortal.Constants
{
    namespace WeChat.Core.Constants
    {
        //public static class MsgType
        //{
        //    public const string Text = "text";
        //    public const string Image = "image";
        //    public const string News = "news";
        //    public const string Voice = "voice";
        //    public const string Video = "video";
        //    public const string Music = "music";
        //    public const string Location = "location";
        //    public const string Link = "link";
        //    public const string Event = "event";

        //}

        public enum ReturnCode
        {
            请求成功 = 0,
            系统繁忙 = -1,
            不合法的凭证类型 = 40002
        }

        public enum MsgType
        {
            Text = 1,
            Image = 2,
            Voice = 3,
            Video = 4,
            ShortVideo = 5,
            Location = 6,
            Link = 7,
            Event = 8
        }

        public enum ResponseType
        {
            Text = 1,
            Image = 2,
            Voice = 3,
            Video = 4,
            Music = 5,
            News = 6
        }

        public enum EventType
        {
            Subscribe = 1,
            Unsubscribe = 2,
            Scan = 3,
            Location = 4,
            Click = 5,
            View = 6,
        }
    }
}