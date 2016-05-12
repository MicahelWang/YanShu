using System.Threading.Tasks;
using System.Web.Http;
using WeChatPortal.Constants.WeChat.Core.Constants;
using WeChatPortal.Entities.WxResult;
using WeChatPortal.Services;

namespace WeChatPortal.Controllers
{
    public class QrCodeController : ApiController
    {
        private readonly WxQrCodeService _service = new WxQrCodeService();
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="sceneId"></param>
        /// <param name="qrCodeType"></param>
        /// <param name="expire"></param>
        /// <returns></returns>
        public async Task<CreateQrCodeResult> Post(string sceneId,QrCodeType qrCodeType=QrCodeType.QrScene, int expire= 1800)
        {
            return await _service.CreateQrCode(sceneId,qrCodeType, expire);
        }
    }
}
