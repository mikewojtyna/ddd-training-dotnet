namespace BuildMySoftware.DDDTraining.Invoicing.Domain
{
    public class InvoicingService
    {
        private ISellerContext _sellerContext;

        public InvoicingService(ISellerContext sellerContext)
        {
            _sellerContext = sellerContext;
        }

        public Invoice CreateInvoice(Order order)
        {
            return new Invoice()
            {
                Seller = _sellerContext.GetSeller(),
                Buyer = order.Buyer,
                Products = order.Products,
                TotalCost = order.TotalCost
            };
        }
    }
}