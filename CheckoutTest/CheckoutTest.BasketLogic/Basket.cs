using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutTest.BasketLogic
{
    public class Basket
    {
        public List<BasketItem> ItemsInBasket { get; private set; }

        public Basket(List<BasketItem> itemsInBasket)
        {
            ItemsInBasket = itemsInBasket;
        }

        public void AddItemToBasket(BasketItem item)
        {
            var basketItems = ItemsInBasket.SingleOrDefault(i => i.CatalogItem.ItemId == item.CatalogItem.ItemId);
            if (basketItems == null)
            {
                ItemsInBasket.Add(item);
            }
            else
            {
                basketItems.SetQuantity(basketItems.Quantity + 1);
            }
        }

        public bool IsItemInBasket(String itemId)
        {
            return ItemsInBasket.SingleOrDefault(i => i.CatalogItem.ItemId == itemId) != null;
        }


        public bool RemoveItem(string itemId)
        {
            if (!IsItemInBasket(itemId)) return false;
            var basketItem = ItemsInBasket.Single(item => item.CatalogItem.ItemId == itemId);
            ItemsInBasket.Remove(basketItem);
            return true;

        }

        public void EmptyBasket()
        {
            ItemsInBasket = new List<BasketItem>();
        }

        //ideally i would model a price with an object containing the different breakdowns, total, with VAT, 
        //Discounted price and so on, but for the scope of this prototipe i'll leave it as double
        //i am aware of the code smell called "primitive obsession" :)
        // https://refactoring.guru/smells/primitive-obsession
        public double GetTotalPrice()
        {
            return ItemsInBasket.Select(s => s.CatalogItem.Price).Sum();
        }


    }
}