namespace webApiTaxi
{
    public interface IOrdersService
    {
        Task<IEnumerable<Orders>> GetAllOrdersAsync();
        Task<Orders?> GetOrdersByIdAsync(int ID);
        Task CreateOrderAsync(Orders order);
        Task UpdateOrderAsync(Orders order);
        Task DeleteOrderAsync(int ID);
    }
}
