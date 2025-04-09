namespace webApiTaxi
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Orders>> GetAllOrdersAsync();
        Task<Orders?> GetOrderByIdAsync(int ID);
        Task AddOrderAsync(Orders order);
        Task UpdateOrderAsync(Orders order);
        Task DeleteOrderAsync(int ID);
    }
}
