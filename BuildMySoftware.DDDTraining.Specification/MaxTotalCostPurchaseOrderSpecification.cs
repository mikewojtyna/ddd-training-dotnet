using BuildMySoftware.DDDTraining.Order;
using BuildMySoftware.DDDTraining.Order.Tests;

namespace BuildMySoftware.DDDTraining.Specification
{
    public class MaxTotalCostPurchaseOrderSpecification : BaseSpecification<PurchaseOrder>
    {
        private Money MaxTotalCost { get; }

        public MaxTotalCostPurchaseOrderSpecification(Money maxTotalCost)
        {
            MaxTotalCost = maxTotalCost;
        }

        public override bool applies(PurchaseOrder t)
        {
            return MaxTotalCost.IsGreaterThan(t.TotalCost());
        }
    }
}