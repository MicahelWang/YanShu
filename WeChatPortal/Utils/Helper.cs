using System;
using System.Linq;
using System.Text;

namespace WeChatPortal.Utils
{
    public static class Helper
    {
        private static readonly string[] Codes;
        private static readonly int CodeLength;
        private static readonly string StartChar;
        static Helper()
        {
            Codes = ConfigSetting.CodeHash.ToCharArray().Select(m => m.ToString()).ToArray();
            CodeLength = Codes.Length;
            StartChar = Codes[0];
        }
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

        public static string ToCodeValue(string code)
        {
            return "";
        }

        public static string CreateCode(this int value)
        {
            string[] result = new string[6];
            for (int i = 0; i < result.Length; i++)
            {
                if (value > 0)
                {
                    result[i] = Codes[value % CodeLength];
                    value = value / CodeLength;
                }
                else
                {
                    result[i] = StartChar;
                }
            }
            return string.Join("", result);

        }



    }
}
