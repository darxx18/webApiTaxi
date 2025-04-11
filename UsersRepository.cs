using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;


namespace webApiTaxi
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<UsersRepository> _logger;
        public UsersRepository(IConfiguration configuration, ILogger<UsersRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = _configuration.GetConnectionString("DefaultConnection");
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                _logger.LogError("Строка подключения к базе данных не найдена!");
                throw new Exception("Строка подключения к базе данных не найдена!");
            }

            // 2. Используем строку подключения для создания SqlConnection
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();  // Не забудьте открыть соединение

                // 3. Выполняем запрос
                string query = "SELECT * FROM Users";

                try // Добавляем блок try-catch для обработки ошибок
                {
                    return await connection.QueryAsync<Users>(query); // Используем Dapper
                }
                catch (SqlException ex)
                {
                    _logger.LogError($"Ошибка при получении всех пользователей: {ex.Message}, {ex.StackTrace}");
                    throw; // Перебрасываем исключение, чтобы вызывающий код мог обработать ошибку
                }
            }
        }
        public async Task<Users?> GetUsersByLoginAsync(string login)
        {
            string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = _configuration.GetConnectionString("DefaultConnection");
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                _logger.LogError("Строка подключения к базе данных не найдена!");
                throw new Exception("Строка подключения к базе данных не найдена!");
            }

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Users WHERE login = @login";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@login", login);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Users
                            {
                                ID = (int)reader["Id"],
                                Lastname = (string)reader["lastname"],
                                Firstname = (string)reader["firstname"],
                                Login= (string)reader["login"],
                                Password = (string)reader["password"]
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
             public async Task AddUserAsync(Users user)
          {
              string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

          if (string.IsNullOrEmpty(connectionString))
          {
              connectionString = _configuration.GetConnectionString("DefaultConnection");
          }

          if (string.IsNullOrEmpty(connectionString))
          {
              _logger.LogError("Строка подключения к базе данных не найдена!");
              throw new Exception("Строка подключения к базе данных не найдена!");
          }
          using (var connection = new SqlConnection(connectionString))
          {
              await connection.OpenAsync();  // Не забудьте открыть соединение

              // 3. Выполняем запрос
              string query = "INSERT INTO Users (lastname, firstname, login, password) " +
                             "VALUES (@lastname, @firstname, @login, @password)";

              try // Добавляем блок try-catch для обработки ошибок
              {
                  await connection.ExecuteAsync(query, user);
              }
              catch (SqlException ex)
              {
                  _logger.LogError($"Ошибка при добавлении пользователя: {ex.Message}, {ex.StackTrace}");
                  throw; // Перебрасываем исключение, чтобы вызывающий код мог обработать ошибку
              }
          }
          }

          public async Task UpdateUserAsync(Users user)
          {
            string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = _configuration.GetConnectionString("DefaultConnection");
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                _logger.LogError("Строка подключения к базе данных не найдена!");
                throw new Exception("Строка подключения к базе данных не найдена!");
            }
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();  // Не забудьте открыть соединение

                // 3. Выполняем запрос
                string query = "UPDATE Users SET lastname = @lastname, firstname = @firstname, login = @login, password = @password WHERE ID = @ID)";

                try // Добавляем блок try-catch для обработки ошибок
                {
                    await connection.ExecuteAsync(query, user);
                }
                catch (SqlException ex)
                {
                    _logger.LogError($"Ошибка при обновлении данных пользователя: {ex.Message}, {ex.StackTrace}");
                    throw; // Перебрасываем исключение, чтобы вызывающий код мог обработать ошибку
                }
            }
          }

          public async Task DeleteUserAsync(int ID)
          {
            string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = _configuration.GetConnectionString("DefaultConnection");
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                _logger.LogError("Строка подключения к базе данных не найдена!");
                throw new Exception("Строка подключения к базе данных не найдена!");
            }

            // 2. Используем строку подключения для создания SqlConnection
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();  // Не забудьте открыть соединение

                // 3. Выполняем запрос
                string query = "DELETE FROM Users WHERE ID = @ID";

                try // Добавляем блок try-catch для обработки ошибок
                {
                    await connection.ExecuteAsync(query, new { ID });
                }
                catch (SqlException ex)
                {
                    _logger.LogError($"Ошибка при удалении пользователя с ID = {ID}: {ex.Message}, {ex.StackTrace}");
                    throw; // Перебрасываем исключение, чтобы вызывающий код мог обработать ошибку
                }
            }
        }
        public async Task<(string? lastName, string? firstName)?> AuthenticateUserAsync(string login, string password)
        {
            string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = _configuration.GetConnectionString("DefaultConnection");
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                _logger.LogError("Строка подключения к базе данных не найдена!");
                throw new Exception("Строка подключения к базе данных не найдена!");
            }

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync(); // Открываем соединение
                    string query = "SELECT lastname, firstname FROM Users WHERE login = @login AND password = @password";
                    _logger.LogInformation($"SQL-запрос: {query}, login: {login}");

                    (string? lastName, string? firstName)? user;
                    try
                    {
                        user = await connection.QueryFirstOrDefaultAsync<(string? lastName, string? firstName)?>(
                               query,
                               new { login = login, password = password });
                    }
                    catch (SqlException ex)
                    {
                        _logger.LogError($"Ошибка при выполнении запроса к БД: {ex.Message}, {ex.StackTrace}");
                        throw; // Перебрасываем исключение
                    }


                    _logger.LogInformation($"Результат из БД: {user?.lastName}, {user?.firstName}");

                    if (user == null)
                    {
                        _logger.LogWarning($"Аутентификация не удалась для пользователя: {login}. Пользователь не найден или неверный пароль.");
                        return null;
                    }

                    _logger.LogInformation($"Успешная аутентификация для пользователя: {login}.");
                    return user;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ошибка аутентификации пользователя: {ex.Message}");
                return null;
            }
        }
        }
}
