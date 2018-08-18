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
            var expectedItem =new CatalogItem ("Item 1", "1234item", 10.50 );

            var basket = new Basket(new List<BasketItem>());
            var basketItem = new BasketItem(new CatalogItem("Item 1", "1234item" , 10.50), 1 );

            basket.UpdateBasketItemQuantity(basketItem);

            Assert.AreEqual(basket.ReturnTotalQuantity() , expectedQuantity);
            Assert.AreEqual(basketItem.CatalogItem, expectedItem);
        }

        [TestMethod]
        public void Remove_an_item_from_existing_basket()
        {
            const int expectedQuantity = 1;
            var expectedItemToBeRemoved = new CatalogItem("Item 1", "1234item", 10.50);
            var expectedItemToStay = new CatalogItem("Item 2", "456item", 33.50);

            var basket = new Basket(new List<BasketItem>
            {
                new BasketItem(expectedItemToBeRemoved,expectedQuantity),
                new BasketItem(expectedItemToStay,expectedQuantity)
            });

            Assert.AreEqual(basket.ReturnTotalQuantity(), 2);

            basket.RemoveItem(expectedItemToBeRemoved.ItemId);

            Assert.AreEqual(basket.ReturnTotalQuantity(), 1);
            Assert.IsTrue(basket.IsItemInBasket(expectedItemToStay.ItemId));
            Assert.IsFalse(basket.IsItemInBasket(expectedItemToBeRemoved.ItemId));

        }

        [TestMethod]
        public void Empty_the_whole_basket()
        {
            const int expectedQuantity = 1;
            var expectedItem1 = new CatalogItem("Item 1", "1234item", 10.50);
            var expectedItem2 = new CatalogItem("Item 2", "456item", 33.50);

            var basket = new Basket(new List<BasketItem>
            {
                new BasketItem(expectedItem1,expectedQuantity),
                new BasketItem(expectedItem2,expectedQuantity)
            });

            Assert.AreEqual(basket.ReturnTotalQuantity(), 2);

            basket.EmptyBasket();

            Assert.AreEqual(basket.ReturnTotalQuantity(), 0);

        }

        [TestMethod]
        public void Calculate_total_for_existing_basket()
        {
            const int expectedQuantity = 1;
            const double expectedPrice = 44;
            var expectedItem1 = new CatalogItem("Item 1", "1234item", 10.50);
            var expectedItem2 = new CatalogItem("Item 2", "456item", 33.50);

            var basket = new Basket(new List<BasketItem>
            {
                new BasketItem(expectedItem1,expectedQuantity),
                new BasketItem(expectedItem2,expectedQuantity)
            });

            Assert.AreEqual(basket.GetTotalPrice() , expectedPrice);
            
        }

        [TestMethod]
        public void Increase_quantity_of_existing_item_inBasket()
        {
            var expectedItemWithQuantityOne = new BasketItem(new CatalogItem("Item 1", "1234item", 10.50),1);
            var expectedItemWithQuantityFive = new BasketItem(new CatalogItem("Item 1", "1234item", 10.50),5);
            var basket = new Basket(new List<BasketItem>());

            basket.UpdateBasketItemQuantity(expectedItemWithQuantityOne);
            Assert.IsTrue(basket.ReturnItemQuantity(expectedItemWithQuantityOne.CatalogItem.ItemId) == 1);
            basket.UpdateBasketItemQuantity(expectedItemWithQuantityOne);
            Assert.IsTrue(basket.ReturnItemQuantity(expectedItemWithQuantityFive.CatalogItem.ItemId) == 2);

            basket.UpdateBasketItemQuantity(expectedItemWithQuantityFive);
            Assert.IsTrue(basket.ReturnItemQuantity(expectedItemWithQuantityFive.CatalogItem.ItemId) == 7);

        }

        [TestMethod]
        public void Decrase_quantity_of_existing_item_inBasket()
        {
            var expectedItem = new BasketItem(new CatalogItem("Item 1", "1234item", 10.50), 5);
            
            var basket = new Basket(new List<BasketItem>());

            basket.UpdateBasketItemQuantity(expectedItem);
            Assert.IsTrue(basket.ReturnItemQuantity(expectedItem.CatalogItem.ItemId) == 5);

            expectedItem.SetQuantity(-2);
            basket.UpdateBasketItemQuantity(expectedItem);
            Assert.IsTrue(basket.ReturnItemQuantity(expectedItem.CatalogItem.ItemId) == 3);

            expectedItem.SetQuantity(-100);
            basket.UpdateBasketItemQuantity(expectedItem);
            Assert.IsTrue(basket.ReturnItemQuantity(expectedItem.CatalogItem.ItemId) == 0);

            expectedItem.SetQuantity(10);
            basket.UpdateBasketItemQuantity(expectedItem);
            Assert.IsTrue(basket.ReturnItemQuantity(expectedItem.CatalogItem.ItemId) == 10);

        }
    }
}
