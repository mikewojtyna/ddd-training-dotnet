using NFluent;
using NUnit.Framework;


namespace BuildMySoftware.DDDTraining.Invoicing.Domain.Tests
{
    public class Tests
    {

        public readonly ISellerContext stabSellerContext = new StubSellerContext();
        [Test]
        public void CanGenerateInvoiceForOrder()
        {
            // given
            InvoicingService service = AnyInvoicingService();
            Order order = AnyOrder();
            // when
            Invoice invoice = service.CreateInvoice(order);
            // then
            Check.That(invoice).IsNotNull();
        }
        public InvoicingService AnyInvoicingService()
        {
            return new InvoicingService(stabSellerContext);
        }
        public Order AnyOrder()
        {
            return new Order();
        }
    }
}