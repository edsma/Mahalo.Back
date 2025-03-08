using System.ComponentModel.DataAnnotations;

namespace Mahalo.Shared.DTOs;

public class ChangePasswordDTO
{
    [DataType(DataType.Password)]
    public string CurrentPassword { get; set; } = null!;

    [DataType(DataType.Password)]
    public string NewPassword { get; set; } = null!;

    public string Confirm { get; set; } = null!;
}