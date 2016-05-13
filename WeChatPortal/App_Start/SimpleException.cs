using System;

namespace WeChatPortal
{
    [Serializable]
    public class SimpleException : Exception
    {
        public int ErrorCode { get; set; }

        public SimpleException() : this(-10000)
        {
        }

        public SimpleException(int errorCode) : this(errorCode, "不明确的异常")
        {

        }

        public SimpleException(int errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public SimpleException(Exception inner) : this(inner.Message, inner)
        {
        }

        public SimpleException(string message, Exception inner) : this(-10000, message, inner)
        {
        }
        public SimpleException(int errorCode, string message, Exception inner) : base(message, inner)
        {
            ErrorCode = errorCode;
        }
    }
}