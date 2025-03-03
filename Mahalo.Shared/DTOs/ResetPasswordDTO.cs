using System.ComponentModel.DataAnnotations;

namespace Mahalo.Shared.DTOs;

public class ResetPasswordDTO
{
    public string Email { get; set; } = null!;

    [DataType(DataType.Password)]
    public string NewPassword { get; set; } = null!;

    public string ConfirmPassword { get; set; } = null!;

    public string Token { get; set; } = null!;
}