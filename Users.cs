using Microsoft.AspNetCore.Identity;

namespace webApiTaxi
{
    public class Users
    {
        public int ID { get; set; }
        public required string Lastname { get; set; }
        public required string Firstname { get; set; }
        public required string Login { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
    }
}
