using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;


namespace webApiTaxi
{
    public class Color_carsRepository : IColor_carsRepository
    {
        private readonly string _connectionString;
        public Color_carsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
             ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public async Task<IEnumerable<Color_cars>> GetAllColorAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Color_cars>("SELECT * FROM Color_cars");
        }
        public async Task<Color_cars?> GetColorByIdAsync(int ID)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Color_cars>("SELECT * FROM Color_cars WHERE ID = @ID", new { ID });
        }

        public async Task AddColorAsync(Color_cars color)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("INSERT INTO Color_cars (title) " +
                "VALUES (@title)", color);
        }

        public async Task UpdateColorAsync(Color_cars color)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("UPDATE Color_cars SET title = @title WHERE ID = @ID", color);
        }

        public async Task DeleteColorAsync(int ID)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("DELETE FROM Color WHERE ID = @ID", new { ID });
        }
    }
}
