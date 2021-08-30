namespace TestNinja.Mocking
{
    public class OrderService
    {
        private readonly IStorage _storage;
        private IOrderRepository _orderRepository;

        public OrderService(IStorage storage)
        {
            _storage = storage;
        }

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public int PlaceOrder(Order order)
        {
            //var orderId = _storage.Store(order);
            var orderId = _orderRepository.saveOrder(order);

            // Some other work

            return orderId; 
        }
    }

    public class Order
    {
    }

    public interface IStorage
    {
        int Store(object obj);
    }
}