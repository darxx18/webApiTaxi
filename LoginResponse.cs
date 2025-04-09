using webApiTaxi;
namespace webApiTaxi
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Role { get; set; } // "admin", "dispatcher" или null/пустая строка в случае неудачи
        public string Token { get; set; } // Если используется JWT
        public string Message { get; set; } // Сообщение об ошибке
    }
}
