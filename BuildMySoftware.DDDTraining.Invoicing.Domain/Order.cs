using BuildMySoftware.DDDTraining.SharedKernel;
using System.Collections.Generic;

namespace BuildMySoftware.DDDTraining.Invoicing.Domain
{
    public class Order
    {
        public Money TotalCost { get; set; }
        public List<Product> Products { get; set; }
        public string Buyer { get;set; }
    }
}