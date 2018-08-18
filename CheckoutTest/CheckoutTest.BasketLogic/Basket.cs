using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutTest.BasketLogic
{
    public class Basket
    {
        private List<BasketItem> _itemsInBasket;

        public Basket(List<BasketItem> itemsInBasket)
        {
            _itemsInBasket = itemsInBasket;
        }

        public void UpdateBasketItemQuantity(BasketItem item)
        {
            var basketItem = _itemsInBasket.SingleOrDefault(i => i.CatalogItem.ItemId == item.CatalogItem.ItemId);
            if (basketItem == null)
            {
                _itemsInBasket.Add(new BasketItem(item));
            }
            else
            {
                basketItem.SetQuantity(basketItem.Quantity + item.Quantity);
                if (basketItem.Quantity < 0) basketItem.SetQuantity(0);
            }
        }

        public bool IsItemInBasket(String itemId)
        {
            return _itemsInBasket.SingleOrDefault(i => i.CatalogItem.ItemId == itemId) != null;
        }


        public bool RemoveItem(string itemId)
        {
            if (!IsItemInBasket(itemId)) return false;
            var basketItem = _itemsInBasket.Single(item => item.CatalogItem.ItemId == itemId);
            _itemsInBasket.Remove(basketItem);
            return true;

        }

        public void EmptyBasket()
        {
            _itemsInBasket = new List<BasketItem>();
        }

        //ideally i would model a price with an object containing the different breakdowns, total, with VAT, 
        //Discounted price and so on, but for the scope of this prototipe i'll leave it as double
        //i am aware of the code smell called "primitive obsession" :)
        // https://refactoring.guru/smells/primitive-obsession
        public double GetTotalPrice()
        {
            return _itemsInBasket.Select(s => s.CatalogItem.Price).Sum();
        }

        public int ReturnItemQuantity(string itemId)
        {
            if(IsItemInBasket(itemId))
            return _itemsInBasket.Single(i => i.CatalogItem.ItemId == itemId).Quantity;
            return 0;
        }

        public int ReturnTotalQuantity()
        {
            return _itemsInBasket.Sum(s => s.Quantity);
        }
    }
}