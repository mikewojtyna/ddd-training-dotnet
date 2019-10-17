using System;
using System.Collections.Generic;
using System.Text;

namespace BuildMySoftware.DDDTraining.Invoicing.Domain
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
    }
}
