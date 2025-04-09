using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;


namespace webApiTaxi
{
    public class OrdersRepository : IOrderRepository
    {
        private readonly string _connectionString;
        public OrdersRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
             ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public async Task<IEnumerable<Orders>> GetAllOrdersAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Orders>("SELECT * FROM Orders");
        }
        public async Task<Orders?> GetOrderByIdAsync(int ID)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Orders>("SELECT * FROM Orders WHERE ID = @ID", new { ID });
        }

        public async Task AddOrderAsync(Orders order)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("INSERT INTO Orders (id_status, time_start, time_end, address_1, address_2, number_km, id_rate, id_types, id_driver, suName_client, name_client, number_client, addition, totalCost) " +
                "VALUES (@id_status, @time_start, @time_end, @address_1, @address_2, @number_km, @id_rate, @id_types, @id_driver, @suName_client, @name_client, @number_client, @addition, @totalCost)", order);
        }

        public async Task UpdateOrderAsync(Orders order)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("UPDATE Orders SET id_status = @id_status, time_start = @time_start, time_end = @time_end, address_1 = @address_1, address_2 = @address_2, number_km = @number_km, id_rate = @id_rate, id_types = @id_types, id_driver = @id_driver, suName_client = @suName_client, name_client = @name_client, number_client = @number_client, addition = @addition, totalCost = @totalCost WHERE ID = @ID", order);
        }

        public async Task DeleteOrderAsync(int ID)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("DELETE FROM Orders WHERE ID = @ID", new { ID });
        }

    }
}
