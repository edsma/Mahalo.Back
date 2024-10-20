using Mahalo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahalo.Shared.DTOs
{
    public class StateDto
    {
        public int Id { get; set; }
        public int CountryId { get; set; }

        public string Name { get; set; } = null!;

        public bool IsActive { get; set; }

        public DateTime CreationDate { get; set; }

        public ICollection<CityDto>? Cities { get; set; }
        public CountryDto? Country { get; set; } = null;
    }
}
