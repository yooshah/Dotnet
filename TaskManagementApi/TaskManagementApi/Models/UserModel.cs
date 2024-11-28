namespace TaskManagementApi.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; } // You might hash this in real applications
        public string Role { get; set; }
    }
}
