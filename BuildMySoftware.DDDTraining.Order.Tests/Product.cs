namespace BuildMySoftware.DDDTraining.Order.Tests
{
    internal class Product
    {
        public Money UnitPrice { get; private set; }

        public Product(Money unitPrice)
        {
            UnitPrice = unitPrice;
        }
    }
}