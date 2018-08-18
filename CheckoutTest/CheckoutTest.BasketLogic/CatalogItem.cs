namespace CheckoutTest.BasketLogic
{
    public class CatalogItem
    {
        public string Name { get; }
        public string ItemId { get; }
        public double Price { get; }

        public CatalogItem(string name, string itemId, double price)
        {
            Name = name;
            ItemId = itemId;
            Price = price;
        }
        public override bool Equals(object obj)
        {
            var item = obj as CatalogItem;

            if (item == null)
            {
                return false;
            }

            // in a relational logic, item id should be enough
            return ItemId.Equals(item.ItemId) && Price.Equals(item.Price) && Name.Equals(item.Name);
        }
    }
}