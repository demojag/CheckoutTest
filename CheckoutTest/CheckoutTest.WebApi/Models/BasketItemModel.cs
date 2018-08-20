using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutTest.WebApi.Models
{
    public class BasketItemModel
    {
        public string BasketId { get; set; }
        public string Name { get; set; }
        public string ItemId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}