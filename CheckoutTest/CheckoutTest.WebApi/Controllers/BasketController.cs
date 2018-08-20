using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CheckoutTest.BasketLogic;
using CheckoutTest.WebApi.Models;

namespace CheckoutTest.WebApi.Controllers
{
    public class BasketController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetBasket(string id)
        {
            var sessionBasket = BasketInMemorySorage.GetBasket(id);
            if (sessionBasket == null)
            {
                return NotFound();
            }
            return Ok(sessionBasket);
        }


        [HttpPut]
        public IHttpActionResult AddItemToBasket(BasketItemModel item)
        {
            try
            {
                var sessionBasket = BasketInMemorySorage.GetBasket(item.BasketId);
                var basket = MapBasketFromModel(sessionBasket);
                basket.AddItem(MapBasketItemModel(item));
                sessionBasket= BasketInMemorySorage.UpdateBasket(item.BasketId,sessionBasket);
                return Ok(sessionBasket);
            }
            catch (Exception e)
            {
                return InternalServerError(new Exception("there was an error mapping the basket item"));
            }
            
        }

        private BasketItem MapBasketItemModel(BasketItemModel model)
        {
            return new BasketItem(new CatalogItem(model.Name, model.ItemId, model.Price), model.Quantity);
        }

        private Basket MapBasketFromModel(BasketModel model)
        {
           var basket = new Basket(new List<BasketItem>());
            foreach (var basketItemModel in model.ItemsInBasket)
            {
                basket.AddItem(MapBasketItemModel(basketItemModel));
            }
           return basket;

        }


    }
}
