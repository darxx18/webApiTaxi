using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace webApiTaxi
{
    public class RateRepository : IRateRepository
    {
        private readonly string _connectionString;
        public RateRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
             ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public async Task<IEnumerable<Rate>> GetAllRateAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Rate>("SELECT * FROM Rate");
        }
        public async Task<Rate?> GetRateByIdAsync(int ID)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Rate>("SELECT * FROM Rate WHERE ID = @ID", new { ID });
        }

        public async Task AddRateAsync(Rate rate)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("INSERT INTO Rate (title, price) " +
                "VALUES (@title, @price)", rate);
        }

        public async Task UpdateRateAsync(Rate rate)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("UPDATE Rate SET title =@title, price = @price WHERE ID = @ID", rate);
        }

        public async Task DeleteRateAsync(int ID)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("DELETE FROM Rate WHERE ID = @ID", new { ID });
        }
    }
}
