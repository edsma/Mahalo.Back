using Mahalo.Shared.Enums;

namespace Mahalo.Shared.DTOs
{
    public class CreateUserDTO
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Language { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Photo { get; set; } = null!;
        public UserType UserType { get; set; }
        public int CityId { get; set; }
    }
}