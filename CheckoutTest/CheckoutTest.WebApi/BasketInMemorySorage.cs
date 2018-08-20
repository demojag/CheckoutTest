using System.Collections.Generic;
using CheckoutTest.WebApi.Models;

namespace CheckoutTest.WebApi
{
    public static class BasketInMemorySorage
    {
        public static Dictionary<string, BasketModel> BasketSession;
        public static void InitializeBasketInMemorySorage()
        {
            BasketSession = new Dictionary<string, BasketModel>();
        }

        public static BasketModel GetBasket(string id)
        {
            try
            {
                var basket = BasketSession[id];
                return basket;
            }
            catch (KeyNotFoundException)
            {
                BasketSession.Add(id, new BasketModel(id,new List<BasketItemModel>()));
                return BasketSession[id];
            }
            
        }

        public static BasketModel UpdateBasket(string id, BasketModel basket)
        {
            BasketSession[id] = basket;
            return basket;
        }
        
    }
}