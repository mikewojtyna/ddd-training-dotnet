namespace BuildMySoftware.DDDTraining.Order
{
    public interface IOrderRepository
    {
        Order findById(OrderId id);
        void save(Order order);
    }
}