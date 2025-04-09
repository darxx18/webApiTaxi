namespace webApiTaxi
{
    public class OrdersService : IOrdersService
    {
        private readonly IOrderRepository _ordersRepository;

        public OrdersService(IOrderRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<IEnumerable<Orders>> GetAllOrdersAsync()
        {
            return await _ordersRepository.GetAllOrdersAsync();
        }
        public async Task<Orders?> GetOrdersByIdAsync(int ID)
        {
            return await _ordersRepository.GetOrderByIdAsync(ID);
        }
        public async Task CreateOrderAsync(Orders order)
        {
            await _ordersRepository.AddOrderAsync(order);
        }

        public async Task UpdateOrderAsync(Orders order)
        {
            await _ordersRepository.UpdateOrderAsync(order);
        }

        public async Task DeleteOrderAsync(int ID)
        {
            await _ordersRepository.DeleteOrderAsync(ID);
        }
    }
}
