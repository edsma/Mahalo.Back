namespace Mahalo.Shared.DTOs;

public class TokenDTO
{
    public string Token { get; set; } = null!;

    public DateTime Expiration { get; set; }
    public int UserType { get; set; }
    public string Photo { get; set; }
}