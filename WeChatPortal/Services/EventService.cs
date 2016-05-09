using System;
using System.Collections.Generic;
using WeChat.Core.XmlModels;
using WeChatPortal.Entities.Data;
using WeChatPortal.Entities.XmlModels.Request;
using WeChatPortal.Entities.XmlModels.Response;

namespace WeChatPortal.Services
{
    public class EventService
    {
        public BaseMessage ClickEvent(RequestEvent request)
        {

            //{
            //        "type": "click",
            //  "name": "保誠++雋陞儲蓄保障計劃EGS",
            //  "key": "BCEGS"
            //},
            //{
            //        "type": "click",
            //  "name": "保诚+危疾终身保CCL3",
            //  "key": "BCCCL3"
            //},
            //{
            //        "type": "click",
            //  "name": "AIA+進泰安心保PCP",
            //  "key": "AIAPCP"
            //},
            //{
            //        "type": "click",
            //  "name": "AIA+充裕未來計劃BP",
            //  "key": "AIABP"
            //}
            switch (request.EventKey)
            {
                //保誠++雋陞儲蓄保障計劃EGS
                case "BCEGS":
                    var bcegsArticles = new List<ArticleEntity>
                    {
                        new ArticleEntity()
                        {
                            Title = "隽升储蓄保障计划",
                            PicUrl = "http://res.eqh5.com/o_1ah9e8o831ema15s7eb5s8l1apui.jpg",
                            Url = "http://c.eqxiu.com/s/uQpyidpB",
                            Description = @"隽升储蓄保障计划
卖点：分红险，老牌热卖，分红率稳定最高（6%）
公司：英国保诚
投保年龄：0-74周岁
保险期限：终身
缴费年限：趸交/5年/10年

产品亮点：
1、免医疗核保
2、中途领取灵活
3、投保年龄可达74周岁

保险责任：
1、保单分红：包括归原红利（增加保额）与特别红利
2、身故保障：被保险人身故，赔付保证现金价值+累积归原红利+特别红利
"
                        }
                    };
                    var bcegsNews = new ResponseNews(request) { Articles = bcegsArticles };
                    return bcegsNews;
                    break;
                case "BCCCL3":
                    var bcccl3Articles = new List<ArticleEntity> {
                        new ArticleEntity()
                        {
                            Title = "危疾终身保",
                            PicUrl = "http://res.eqh5.com/o_1ah6un6a7h9pt65p0u17rh1ik6e.jpg",
                            Url = "http://x.eqxiu.com/s/lP2qFoG5",
                            Description = @"特点：重疾险，分红率高（保额递增），核保较严（适合年轻人）
公司：英国保诚
投保年龄：0-64周岁
保险期限：终身
缴费年限：5年/10年/15年/20年或交至55岁/交至65岁
等待期：90天
产品亮点
1、赠送10年35%基本保额（未成年人50%）；
2、早期重疾提前给付；
3、指定重疾额外赔付20%；
4、保10种未成年人高发疾病；
5、美元保单，境外资产；
保险责任
1、15种轻症赔付20%当时保额，最多1次
2、原位癌与冠状动脉血管成形术赔付25%当时保额，最多2次
3、重疾保障（52种）：确诊重疾，赔付当时保额+分红
4：指定严重疾病额外保障，除赔付重疾保险金外，额外赔付20%当时保额
5、身故保障：赔付当时保额+分红
"
                        }
                    };
                    var bcccl3News = new ResponseNews(request) { Articles = bcccl3Articles };
                    return bcccl3News;
                    break;
                case "AIAPCP":
                    var aiapcpArticles = new List<ArticleEntity> {
                        new ArticleEntity()
                        {
                            Title = "加裕倍安保",
                            PicUrl = "http://res.eqh5.com/o_1ahr4ti7r4gp1lo716j9145j13uik.png",
                            Url = "http://a.eqxiu.com/s/1Flwv9cb",
                            Description = @"加裕倍安保
卖点：重疾险，保障广，性价比高
公司：AIA友邦
投保年龄：15日—65岁
保险期限：至100岁
缴费年限：10年/18年/25年
产品亮点：100种疾病保障+身故保障+储蓄分红
保费豁免：一旦重疾索赔，豁免后续保费
保险责任：
1、严重疾病（54种）：基本保额-已付的保额+期满红利
2、非严重疾病（1种）：基本保额50%-已付的保额+期满红利
3、早期危疾赔偿（39种）、严重儿童疾病赔偿（7种）：基本保额的20%+部分期满红利
4、身故赔偿：基本保额-已付的保额+累计红利+期满红利
5、头十年升级保障：30岁以下额外50%，31岁以上额外35%
6、癌症多倍赔偿：最高可达保额的260%（仅适用于加强版）
"
                        }
                    };
                    var aiapcpNews = new ResponseNews(request) { Articles = aiapcpArticles };
                    return aiapcpNews;
                    break;
                case "AIABP":
                    var aiabpArticles = new List<ArticleEntity> {
                        new ArticleEntity()
                        {
                            Title = "充裕未来",
                            PicUrl = "http://res.eqh5.com/o_1ah9fhctm1t11li41r31ten1bb9c.jpg",
                            Url = "http://c.eqxiu.com/s/YbvWL64V",
                            Description = @"充裕未来
卖点：分红险，分红率高，挑战隽升（宣传达7%，但新产品，未经长期验证）
公司：AIA友邦
投保年龄：15日-74周岁
保险期限：终身
缴费年限： 5年/10年

产品亮点：
1、400万美元内免医疗核保
2、活动期间大额保单有折扣
3、投保年龄可达74周岁

保险责任：
1、保单分红：包括复归红利（增加保额）与额外花红
2、身故保障：被保险人身故，赔付保证现金价值+累积复归红利+额外花红"
                        }
                    };
                    var aiabpNews = new ResponseNews(request) { Articles = aiabpArticles };
                    return aiabpNews;
                    break;
                case "Appointment":
                    var appointmentResponse = new ResponseText(request)
                    {
                        Content = "您的预约我们已经收到，稍后我们会有工作人员和你联系确认。"
                    };
                    return appointmentResponse;
                    break;
                default:
                    throw new ArgumentNullException();
            }
        }
    }
}