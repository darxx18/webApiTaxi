using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;


namespace webApiTaxi
{
    public class CarsRepository : ICarsRepository
    {
        private readonly string _connectionString;
        public CarsRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
             ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public async Task<IEnumerable<Cars>> GetAllCarsAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Cars>("SELECT * FROM Cars");
        }
        public async Task<Cars?> GetCarsByIdAsync(int ID)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Cars>("SELECT * FROM Cars WHERE ID = @ID", new { ID });
        }

        public async Task AddCarAsync(Cars car)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("INSERT INTO Cars (id_brand, model_car, number, id_color, id_driv, year_car, number_regcert, repair) " +
                "VALUES (@id_brand, @model_car, @number, @id_color, @id_driv, @year_car, @number_regcert, @repair)", car);
        }

        public async Task UpdateCarAsync(Cars car)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("UPDATE Cars SET id_brand = @id_brand, model_car=@model_car, number=@number, id_color=@id_color, id_driv=@id_driv, year_car=@year_car, number_regcert=@number_regcert, repair=@repair WHERE ID = @ID",  car);
        }

        public async Task DeleteCarAsync(int ID)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("DELETE FROM Cars WHERE ID = @ID", new { ID });
        }
    }
}
