namespace CheckoutTest.BasketLogic
{
    public class BasketItem
    {
        public CatalogItem CatalogItem { get; }
        public int Quantity { get; private set; }

        public BasketItem(CatalogItem catalogItem, int quantity)
        {
            CatalogItem = catalogItem;
            Quantity = quantity;
        }

        public BasketItem(BasketItem item)
        {
            CatalogItem = new CatalogItem(item.CatalogItem.Name, item.CatalogItem.ItemId, item.CatalogItem.Price);
            Quantity = item.Quantity;
        }

        public void SetQuantity(int newQuantity)
        {
            Quantity = newQuantity;
        }
    }
}