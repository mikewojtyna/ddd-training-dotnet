namespace BuildMySoftware.DDDTraining.Order
{
    public class OrderFactory
    {
        public OrderPlaced placeOrder()
        {
            // inject any potential dependencies here
            // add some domain logic
            return new OrderPlaced(new Order());
        }
    }
}