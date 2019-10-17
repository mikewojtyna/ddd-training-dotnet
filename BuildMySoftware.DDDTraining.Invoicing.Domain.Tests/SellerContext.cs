namespace BuildMySoftware.DDDTraining.Invoicing.Domain.Tests
{
    public class StubSellerContext : ISellerContext
    {
        public string GetSeller()
        {
            return string.Empty;
        }
    }
}