using BuildMySoftware.DDDTraining.SharedKernel;
using System;
using System.Collections.Generic;

namespace BuildMySoftware.DDDTraining.Invoicing.Domain
{
    public class Invoice
    {
        public string Seller { get; set; }
        public string Buyer { get; set; }
        public List<Product> Products { get; set; }
        public Money TotalCost { get; set; }
    }
}
