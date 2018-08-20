using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CheckoutTest.BasketLogic;

namespace CheckoutTest.WebApi.Controllers
{
    public class ProductController : ApiController
    {
        public List<CatalogItem> Products = new List<CatalogItem>()
        {
            new CatalogItem("shoes", "s001", 15.50),
            new CatalogItem("trousers", "t001", 18.00),
            new CatalogItem("Long trousers", "t002", 35.50),
            new CatalogItem("t-shirt", "ts001", 5.70)

        };

        public IHttpActionResult GetProduct(string id)
        {
            var product = Products.FirstOrDefault((p) => p.ItemId == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
