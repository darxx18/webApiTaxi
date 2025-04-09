using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace webApiTaxi
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            var users = await _usersService.GetAllUsersAsync();
            return Ok(users);
        }

       
        [HttpPost("authenticate")] 
        public async Task<ActionResult<Tuple<string, string>>> Authenticate(LoginRequest model)
        {
            if (model == null || string.IsNullOrEmpty(model.login) || string.IsNullOrEmpty(model.password))
            {
                return BadRequest("Необходимо указать логин и пароль.");
            }

            var userData = await _usersService.AuthenticateUserAsync(model.login, model.password); 

            if (userData == null)
            {
                return Unauthorized("Неверный логин или пароль.");
            }

            return Ok(userData); 
        }
    
       
        [HttpGet("{ID}")]
        public async Task<ActionResult<Users>> GetUsers(string login)
        {
            var users = await _usersService.GetUsersByLoginAsync(login);
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(Users user)
        {
            await _usersService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUsers), new { ID = user.ID }, user);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(Users user)
        {
            await _usersService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{ID}")]
        public async Task<ActionResult> DeleteUser(int ID)
        {
            await _usersService.DeleteUserAsync(ID);
            return NoContent();
        }
    }
}
