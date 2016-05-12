namespace WeChatPortal.Constants
{
    namespace WeChat.Core.Constants
    {
        public enum CommonJsonSendType
        {
            GET,
            POST
        }
        public enum QrCodeType
        {
            /// <summary>
            /// 临时二维码
            /// </summary>
            QrScene=0,
            /// <summary>
            /// 永久二维码
            /// </summary>
            QrLimitScene=1
        }
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