using Mahalo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahalo.Shared.DTOs;

public class UserDTO : User
{
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    public string PasswordConfirm { get; set; } = null!;

    public string Language { get; set; } = null!;
}