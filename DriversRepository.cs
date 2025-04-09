using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;


namespace webApiTaxi
{
    public class DriversRepository : IDriversRepository
    {
        private readonly string _connectionString;
        public DriversRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
             ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public async Task<IEnumerable<Drivers>> GetAllDriverAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Drivers>("SELECT * FROM Drivers");
        }
        public async Task<Drivers?> GetDriverByIdAsync(int ID)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Drivers>("SELECT * FROM Drivers WHERE ID = @ID", new { ID });
        }

        public async Task AddDriverAsync(Drivers driver)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("INSERT INTO Drivers (lastname, firstname, middle_name, number_phone, works) " +
                "VALUES (@lastname, @firstname, @middle_name, @number_phone, @works)", driver);
        }

        public async Task UpdateDriverAsync(Drivers driver)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("UPDATE Drivers SET lastname = @lastname, firstname = @firstname, middle_name = @middle_name, number_phone = @number_phone, works = @works WHERE ID = @ID", driver);
        }

        public async Task DeleteDriverAsync(int ID)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("DELETE FROM Drivers WHERE ID = @ID", new { ID });
        }
    }
}
