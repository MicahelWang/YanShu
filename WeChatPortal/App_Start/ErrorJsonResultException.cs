using System;
using System.Runtime.Serialization;

namespace WeChatPortal
{
    [Serializable]
    public class ErrorJsonResultException : Exception
    {

        public string  Url { get; set; }        
        public ErrorJsonResultException()
        {
        }

        public ErrorJsonResultException(string message) : base(message)
        {
        }

        public ErrorJsonResultException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ErrorJsonResultException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}