namespace Mahalo.Shared.DTOs;

public class UserDTO
{

    public string Language { get; set; } = null!;
    public string CityId { get; set; } = null!;
    public string DocumentNumber { get; set; } = null!;
    public int DocumentTypeId { get; set; }
    public int UserType { get; set; }
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Photo { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string? Id { get; set; }
    public DateTime CreationDate { get; set; }
    public bool IsActive { get; set; }
}