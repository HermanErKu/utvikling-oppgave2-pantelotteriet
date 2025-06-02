using Backend.Models.Enums;

namespace Backend.DTOs
{
    public class UserCreateDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string PasswordHash { get; set; }

        public Role Role { get; set; }
    }
}
