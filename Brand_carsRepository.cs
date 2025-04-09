using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;


namespace webApiTaxi
{
    public class Brand_carsRepository : IBrand_carsRepository
    {
        private readonly string _connectionString;
        public Brand_carsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
             ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public async Task<IEnumerable<Brand_cars>> GetAllBrandAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Brand_cars>("SELECT * FROM Brand_cars");
        }
        public async Task<Brand_cars?> GetBrandByIdAsync(int ID)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Brand_cars>("SELECT * FROM Brand_cars WHERE ID = @ID", new { ID });
        }

        public async Task AddBrandAsync(Brand_cars brand)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("INSERT INTO Brand_cars (title) " +
                "VALUES (@title)", brand);
        }

        public async Task UpdateBrandAsync(Brand_cars brand)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("UPDATE Brand_cars SET title = @title WHERE ID = @ID", brand);
        }

        public async Task DeleteBrandAsync(int ID)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("DELETE FROM Brand_cars WHERE ID = @ID", new { ID });
        }
    }
}
