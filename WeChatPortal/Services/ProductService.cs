

using System.Collections.Generic;
using System.Linq;
using WeChatPortal.Constants;
using WeChatPortal.Models;
using WeChatPortal.Utils.Caching;

namespace WeChatPortal.Services
{
    public class ProductService:BaseService
    {
        private List<Product> Products
            => CacheManager.Get(CacheKey.Products, GetAllProducts);
        private readonly InsuranceDb _db = new InsuranceDb();
        public List<Product> GetProducts()
        {
            return Products;
        }

        private List<Product> GetAllProducts()
        {
            return _db.Products.ToList();
        }


        public Product GetprodctById(int id)
        {
            return Products.FirstOrDefault(m => m.ID == id);
        }
    }
}