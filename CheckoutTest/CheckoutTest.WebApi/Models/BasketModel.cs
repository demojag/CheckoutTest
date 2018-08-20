using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutTest.WebApi.Models
{
    public class BasketModel
    {
        private List<BasketItemModel> _list;

        public BasketModel(string basketId, List<BasketItemModel> list)
        {
            BasketId = basketId;
            this._list = list;
        }

        public string BasketId { get; set; }
        public List<BasketItemModel> ItemsInBasket { get; set; }
    }
    
}