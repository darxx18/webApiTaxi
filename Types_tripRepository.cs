using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace webApiTaxi
{
    public class Types_tripRepository : ITypes_tripRepository
    {
        private readonly string _connectionString;
        public Types_tripRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
             ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public async Task<IEnumerable<Types_trip>> GetAllTypesAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Types_trip>("SELECT * FROM Types_trip");
        }
        public async Task<Types_trip?> GetTypesByIdAsync(int ID)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Types_trip>("SELECT * FROM Types_trip WHERE ID = @ID", new { ID });
        }

        public async Task AddTypeAsync(Types_trip type)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("INSERT INTO Types_trip (title) " +
                "VALUES (@title)", type);
        }

        public async Task UpdateTypeAsync(Types_trip type)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("UPDATE Types_trip SET title = @title WHERE ID = @ID", type);
        }

        public async Task DeleteTypeAsync(int ID)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("DELETE FROM Types_trip WHERE ID = @ID", new { ID });
        }
    }
}
