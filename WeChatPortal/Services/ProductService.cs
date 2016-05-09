using System.Collections.Generic;
using System.Linq;
using WeChatPortal.Models;

namespace WeChatPortal.Services
{
    public class ProductService:BaseService
    {
        private readonly InsuranceDb _db = new InsuranceDb();
        public IEnumerable<Product> GetProducts()
        {
            return _db.Product.ToList();
        }


        public Product GetprodctById(int id)
        {
            return _db.Product.FirstOrDefault(m => m.ID == id);
        }
    }
}