namespace BuildMySoftware.DDDTraining.Order
{
    public interface IPurchaseOrderRepository
    {
        PurchaseOrder Load(PurchaseOrderId id);
        void Save(PurchaseOrder order);
    }
}