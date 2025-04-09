using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;


namespace webApiTaxi
{
    public class StatusesRepository : IStatusesRepository
    {
        private readonly string _connectionString;
        public StatusesRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
             ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public async Task<IEnumerable<Statuses>> GetAllStatusesAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Statuses>("SELECT * FROM Statuses");
        }
        public async Task<Statuses?> GetStatusesByIdAsync(int ID)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Statuses>("SELECT * FROM Statuses WHERE ID = @ID", new { ID });
        }

        public async Task AddStatusAsync(Statuses status)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("INSERT INTO Statuses (title) " +
                "VALUES (@title)", status);
        }

        public async Task UpdateStatusAsync(Statuses status)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("UPDATE Statuses SET title = @title WHERE ID = @ID", status);
        }

        public async Task DeleteStatusAsync(int ID)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("DELETE FROM Statuses WHERE ID = @ID", new { ID });
        }
    }
}
