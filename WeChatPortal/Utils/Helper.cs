using System;
using System.Text;

namespace WeChatPortal.Utils
{
    public static class Helper
    {
        /// <summary>
        /// 验证微信签名
        /// </summary>
        public static bool CheckSignature(string token, string signature, string timestamp, string nonce)
        {
            string[] arrTmp = { token, timestamp, nonce };

            Array.Sort(arrTmp);
            string tmpStr = string.Join("", arrTmp);
            tmpStr = Sha1(tmpStr);
            var resultValue = tmpStr.ToLower();
            if (resultValue == signature)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static string Sha1(string text)
        {
            byte[] cleanBytes = Encoding.Default.GetBytes(text);
            byte[] hashedBytes = System.Security.Cryptography.SHA1.Create().ComputeHash(cleanBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }
    }
}
