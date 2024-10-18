
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahalo.Shared.DTOs;

public class ChangePasswordDTO
{
    [DataType(DataType.Password)]
    public string CurrentPassword { get; set; } = null!;

    [DataType(DataType.Password)]
    public string NewPassword { get; set; } = null!;

    public string Confirm { get; set; } = null!;
}