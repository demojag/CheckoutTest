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

        public void SetQuantity(int newQuantity)
        {
            Quantity = newQuantity;
        }

    }
}