namespace BuildMySoftware.DDDTraining.Order.Tests
{
    internal class OrderItem
    {
        private int _quantity;
        private Product _product;

        public OrderItem(int quanity, Product product)
        {
            _quantity = quanity;
            _product = product;
        }

        public void IncreaseQuantity()
        {
            _quantity++;
        }

        internal Money Cost()
        {
            return _product.UnitPrice.MultipiedBy(_quantity);
        }
    }
}