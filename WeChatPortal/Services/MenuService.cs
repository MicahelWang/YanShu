using System.Collections.Generic;
using System.Linq;
using WeChat.Core.XmlModels;
using WeChatPortal.Models;
using static System.String;

namespace WeChatPortal.Services
{
    public class MenuService
    {
        private readonly InsuranceDb _db = new InsuranceDb();
        public IEnumerable<Menu> GetMenus()
        {
            return _db.Menu.Include(".Menu1").ToList();
        }
    }
}