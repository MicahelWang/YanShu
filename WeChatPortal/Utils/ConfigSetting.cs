using System.Configuration;

namespace WeChatPortal.Utils
{
    public class ConfigSetting
    {
        #region Private Methods

        public static string GetValue(string key)
        {
            string value = ConfigurationManager.AppSettings[key];
            if (!string.IsNullOrEmpty(value))
            {
                return value;
            }
            return string.Empty;
        }

        public static string GetString(string key, string defaultValue = "")
        {
            string setting = GetValue(key);
            if (!string.IsNullOrEmpty(setting))
            {
                return setting;
            }
            return defaultValue;
        }

        public static bool GetBool(string Key, bool DefaultValue)
        {
            string setting = GetValue(Key);
            if (!string.IsNullOrEmpty(setting))
            {
                switch (setting.ToLower())
                {
                    case "false":
                    case "0":
                    case "n":
                        return false;
                    case "true":
                    case "1":
                    case "y":
                        return true;
                }
            }
            return DefaultValue;
        }

        public static int GetInt(string key, int defaultValue)
        {
            string setting = GetValue(key);
            if (!string.IsNullOrEmpty(setting))
            {
                int i;
                if (int.TryParse(setting, out i))
                {
                    return i;
                }
            }
            return defaultValue;
        }

        public static double GetDouble(string key, double defaultValue)
        {
            string setting = GetValue(key);
            if (!string.IsNullOrEmpty(setting))
            {
                double d;
                if (double.TryParse(setting, out d))
                {
                    return d;
                }
            }
            return defaultValue;
        }

        public static byte GetByte(string key, byte defaultValue)
        {
            string setting = GetValue(key);
            if (!string.IsNullOrEmpty(setting))
            {
                byte b;
                if (byte.TryParse(setting, out b))
                {
                    return b;
                }
            }

            return defaultValue;
        }

        public static string ConnenctionString(string key)
        {
            if (ConfigurationManager.ConnectionStrings[key] == null)
            {
                return null;
            }
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }

        #endregion


        private const string TokenKey = "Token";
        private const string AppIdKey = "AppId";
        private const string AppSecretKey = "AppSecret";
        private const string EncodingAesKeyName = "EncodingAesKey";
        private const string EncryptKey = "Encrypt";

        #region Public Properties

        public static string AppId => GetString(AppIdKey, "");


        public static string AppSecret => GetString(AppSecretKey, "");
        public static string Token => GetString(TokenKey, "");

        public static string EncodingAesKey => GetString(EncodingAesKeyName, "");/// <summary>
                                                                                 /// 是否加密
                                                                                 /// </summary>
        public static bool Encrypt => GetBool(EncryptKey, false);

        #endregion
    }



}
