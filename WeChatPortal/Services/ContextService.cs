using System;
using System.Linq;
using WeChatPortal.Constants.WeChat.Core.Constants;
using WeChatPortal.Entities.Data;
using WeChatPortal.Entities.XmlModels;
using WeChatPortal.Entities.XmlModels.Request;
using WeChatPortal.Entities.XmlModels.Response;
using WeChatPortal.Models;

namespace WeChatPortal.Services
{
    public class ContextService
    {
        private readonly InsuranceDb _db = new InsuranceDb();


        public Article GetContextByKey(string key)
        {
            var context = _db.Article.Include("ArticleContent.Content").FirstOrDefault(m => m.KeyName==key);
            return context;
        }

        public BaseMessage GetResponseByEvent(RequestEvent request)
        {
            if (string.Equals(request.Event, EventType.Click.ToString(), StringComparison.CurrentCultureIgnoreCase))
            {
                var eventContext = GetContextByKey(request.EventKey);
                if (eventContext==null)
                {
                    return null;
                }
                switch (eventContext.MsgType)
                {
                    case (int)ResponseType.News:
                        var newsResponse = new ResponseNews(request)
                        {
                            ArticleCount = eventContext.ArticleContent.Count,
                            Articles =
                                eventContext.ArticleContent.OrderBy(m => m.Sort).Select(content => new ArticleEntity()
                                {
                                    Title = content.Content.Title,
                                    PicUrl = content.Content.Image,
                                    Description = content.Content.Description,
                                    Url = content.Content.Url,
                                }).ToList()
                        };
                        return newsResponse;
                    case (int)ResponseType.Text:
                        var textResponse = new ResponseText(request);
                        var articles = eventContext.ArticleContent.FirstOrDefault();
                        var text = articles == null ? "" : articles.Content.Description;
                        textResponse.Content = text;
                        return textResponse;
                }
            }
            return null;
        }

    }
}