using System;
using System.Threading.Tasks;
using WeChatPortal.Constants;
using WeChatPortal.Constants.WeChat.Core.Constants;
using WeChatPortal.Entities.WxResult;

namespace WeChatPortal.Services
{
    public class WxQrCodeService : BaseService
    {
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="sceneStr">场景值ID（字符串形式的ID），字符串类型，长度限制为1到64</param>
        /// <param name="qrCodeType" ref="QrCodeType">二维码类型</param>
        /// <param name="expireSeconds">有效期【临时二维码需要设置】</param>
        /// <returns></returns>
        public async Task<CreateQrCodeResult> CreateQrCode(string sceneStr, QrCodeType qrCodeType = QrCodeType.QrScene, int expireSeconds = 1800)
        {
            object data = null;

            if (qrCodeType == QrCodeType.QrScene)
            {

                data = new
                {
                    expire_seconds = expireSeconds,
                    action_name = "QR_STR_SCENE",
                    action_info = new
                    {
                        scene = new
                        {
                            scene_str = sceneStr
                        }
                    }
                };
            }
            else
            {
                data = new
                {
                    action_name = "QR_LIMIT_STR_SCENE",
                    action_info = new
                    {
                        scene = new
                        {
                            scene_str = sceneStr
                        }
                    }
                };
            }
            var url = RequestUrl.PostCreateQrCodeUrl(this.Token);

            return await PostSendJson<CreateQrCodeResult>(url, data);
        }
       
    }
}