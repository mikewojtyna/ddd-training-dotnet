using BuildMySoftware.DDDTraining.SharedKernel;

namespace BuildMySoftware.DDDTraining.Order
{
    internal class OrderItem
    {
        private Product Product { get; }
        private int Quantity { get; set; }

        internal OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        internal void IncreaseQuantity()
        {
            Quantity++;
        }

        internal Money Cost()
        {
            return Product.Price.Multiply(Quantity);
        }
    }
}