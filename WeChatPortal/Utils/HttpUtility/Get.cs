/*----------------------------------------------------------------
    Copyright (C) 2016 Senparc
    
    文件名：Get.cs
    文件功能描述：Get
    
    
    创建标识：Senparc - 20150211
    
    修改标识：Senparc - 20150303
    修改描述：整理接口
----------------------------------------------------------------*/

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeChatPortal.Utils.HttpUtility
{
    public static class Get
    {
        #region 同步方法

        /// <summary>
        /// GET方式请求URL，并返回T类型
        /// </summary>
        /// <typeparam name="T">接收JSON的数据类型</typeparam>
        /// <param name="url"></param>
        /// <param name="callBack"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static T GetJson<T>(string url, Action<string> callBack,Encoding encoding = null)
        {
            string returnText = RequestUtility.HttpGet(url, encoding);

            //WeixinTrace.SendLog(url, returnText);

            //JavaScriptSerializer js = new JavaScriptSerializer();

            if (returnText.Contains("errcode"))
            {
                callBack?.Invoke(returnText);
            }

            //T result = js.Deserialize<T>(returnText);
            T result = returnText.DeserializeJson<T>();

            return result;
        }

        /// <summary>
        /// 从Url下载
        /// </summary>
        /// <param name="url"></param>
        /// <param name="stream"></param>
        public static void Download(string url, Stream stream)
        {
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3
            //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);  

            WebClient wc = new WebClient();
            var data = wc.DownloadData(url);
            foreach (var b in data)
            {
                stream.WriteByte(b);
            }
        }

        #endregion

        #region 异步方法

        /// <summary>
        /// 异步GetJsonA
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> GetJsonAsync<T>(string url, Encoding encoding = null)
        {
            string returnText = await RequestUtility.HttpGetAsync(url, encoding);
          
            var result = returnText.DeserializeJson<T>();
            return result;
        }

        /// <summary>
        /// 异步从Url下载
        /// </summary>
        /// <param name="url"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static async Task DownloadAsync(string url, Stream stream)
        {
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3
            //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);  

            WebClient wc = new WebClient();
            var data = await wc.DownloadDataTaskAsync(url);
            await stream.WriteAsync(data, 0, data.Length);
            //foreach (var b in data)
            //{
            //    stream.WriteAsync(b);
            //}
        }

        #endregion
    }
}
