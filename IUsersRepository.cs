using System.Collections.Generic;
using System.Threading.Tasks;
namespace webApiTaxi
{
    public interface IUsersRepository
    {
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<Users?> GetUsersByLoginAsync(string login);
        Task AddUserAsync(Users user);
        Task UpdateUserAsync(Users user);
        Task DeleteUserAsync(int ID);
        Task<(string? lastName, string? firstName)?> AuthenticateUserAsync(string login, string password);
    }
}
