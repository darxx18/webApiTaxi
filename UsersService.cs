using System.Collections.Generic;
using System.Threading.Tasks;
namespace webApiTaxi
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await _usersRepository.GetAllUsersAsync();
        }
        public async Task<Users?> GetUsersByLoginAsync(string login)
        {
            return await _usersRepository.GetUsersByLoginAsync(login);
        }
        public async Task CreateUserAsync(Users user)
        {
            await _usersRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(Users user)
        {
            await _usersRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int ID)
        {
            await _usersRepository.DeleteUserAsync(ID);
        }
        public async Task<(string? lastName, string? firstName)?> AuthenticateUserAsync(string login, string password)
        {
            return await _usersRepository.AuthenticateUserAsync(login, password);
        }
    }
}
