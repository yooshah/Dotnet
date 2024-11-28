using TaskManagementApi.Models;

namespace TaskManagementApi.Services
{
    public class AuthService
    {
        private readonly List<UserModel> _users;
        private readonly JwtService _jwtService;

        public AuthService(JwtService jwtService)
        {
            _users = new List<UserModel>
        {
            new UserModel { Username = "admin", Password = "admin", Role = "Admin" },
            new UserModel { Username = "user", Password = "user", Role = "User" }
        };
            _jwtService = jwtService;
        }

        public string Authenticate(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user == null) return null;

            // Generate JWT Token
            return _jwtService.GenerateJwtToken(user.Username, user.Role);
        }
    }

}
