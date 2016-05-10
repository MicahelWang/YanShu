using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeChatPortal.Models;
using WeChatPortal.Services;

namespace WeChatPortal.Controllers
{
    public class ProductController : ApiController
    {
        readonly ProductService _service = new ProductService();

        public IEnumerable<Product> Get()
        {
            return _service.GetProducts();
        }

        public Product Get(int id)
        {
            return _service.GetprodctById(id);
        }
    }
}
