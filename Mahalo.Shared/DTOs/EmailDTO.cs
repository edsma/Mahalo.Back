
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahalo.Shared.DTOs;

public class EmailDTO
{
    public string Email { get; set; } = null!;

    public string Language { get; set; } = null!;
}