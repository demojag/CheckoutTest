using System;
using System.Collections.Generic;
using CheckoutTest.BasketLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.CheckoutTest.BasketLogic
{
    [TestClass]
    public class BasketLogic
    {
        [TestMethod]
        public void Create_a_basket_and_add_an_item()
        {
            const int expectedQuantity = 1;
            CatalogItem expectedItem =new CatalogItem ("Item 1", "1234item", 10.50 );

            Basket basket = new Basket(new List<BasketItem>());
            BasketItem basketItem = new BasketItem(new CatalogItem("Item 1", "1234item" , 10.50), 1 );

            basket.AddItemToBasket(basketItem);

            Assert.AreEqual(basket.ItemsInBasket.Count, expectedQuantity);
            Assert.AreEqual(basketItem.CatalogItem, expectedItem);
        }

        [TestMethod]
        public void Remove_an_item_from_existing_basket()
        {
            const int expectedQuantity = 1;
            CatalogItem expectedItemToBeRemoved = new CatalogItem("Item 1", "1234item", 10.50);
            CatalogItem expectedItemToStay = new CatalogItem("Item 2", "456item", 33.50);

            Basket basket = new Basket(new List<BasketItem>
            {
                new BasketItem(expectedItemToBeRemoved,expectedQuantity),
                new BasketItem(expectedItemToStay,expectedQuantity)
            });

            Assert.AreEqual(basket.ItemsInBasket.Count, 2);

            basket.RemoveItem(expectedItemToBeRemoved.ItemId);

            Assert.AreEqual(basket.ItemsInBasket.Count, 1);
            Assert.IsTrue(basket.IsItemInBasket(expectedItemToStay.ItemId));
            Assert.IsFalse(basket.IsItemInBasket(expectedItemToBeRemoved.ItemId));

        }

        [TestMethod]
        public void Empty_the_whole_basket()
        {
            const int expectedQuantity = 1;
            CatalogItem expectedItem1 = new CatalogItem("Item 1", "1234item", 10.50);
            CatalogItem expectedItem2 = new CatalogItem("Item 2", "456item", 33.50);

            Basket basket = new Basket(new List<BasketItem>
            {
                new BasketItem(expectedItem1,expectedQuantity),
                new BasketItem(expectedItem2,expectedQuantity)
            });

            Assert.AreEqual(basket.ItemsInBasket.Count, 2);

            basket.EmptyBasket();

            Assert.AreEqual(basket.ItemsInBasket.Count, 0);

        }

        [TestMethod]
        public void Calculate_total_for_existing_basket()
        {
            const int expectedQuantity = 1;
            const double expectedPrice = 44;
            CatalogItem expectedItem1 = new CatalogItem("Item 1", "1234item", 10.50);
            CatalogItem expectedItem2 = new CatalogItem("Item 2", "456item", 33.50);

            Basket basket = new Basket(new List<BasketItem>
            {
                new BasketItem(expectedItem1,expectedQuantity),
                new BasketItem(expectedItem2,expectedQuantity)
            });

            Assert.AreEqual(basket.GetTotalPrice() , expectedPrice);
            
        }
    }
}
