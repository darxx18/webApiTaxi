using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;


namespace webApiTaxi
{
    public class UsersRepository : IUsersRepository
    {
        private readonly string _connectionString;
        public UsersRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
             ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Users>("SELECT * FROM Users");
        }
        public async Task<Users?> GetUsersByLoginAsync(string login)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<Users>("SELECT * FROM Users WHERE login = @login", new { login });
        }

        public async Task AddUserAsync(Users user)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("INSERT INTO Users (lastname, firstname, login, password, role) " +
                "VALUES (@lastname, @firstname, @login, @password, @role)", user);
        }

        public async Task UpdateUserAsync(Users user)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("UPDATE Users SET lastname = @lastname, firstname = @firstname, login = @login, password =@password, role = @role WHERE ID = @ID", user);
        }

        public async Task DeleteUserAsync(int ID)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync("DELETE FROM Users WHERE ID = @ID", new { ID });
        }
        public async Task<(string? lastName, string? firstName)?> AuthenticateUserAsync(string login, string password)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                
                var user = await connection.QueryFirstOrDefaultAsync<(string, string)>("SELECT lastname, firstname FROM Users WHERE login = @login AND password = @password", new { login = login, password = password }); //ЗАменить password на хеш
                string query = "SELECT lastname, firstname FROM Users WHERE login = @login AND password = @password";
                return user;

            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error authenticating user: {ex.Message}");
                return (null, null); 
            }
        }
    }
}
