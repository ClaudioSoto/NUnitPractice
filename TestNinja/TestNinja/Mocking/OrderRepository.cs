using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IOrderRepository
    {
        int saveOrder(Order order);
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly IStorage _storage;
        public int saveOrder(Order order)
        {
            var orderId = _storage.Store(order);

            return orderId;
        }
    }
}
