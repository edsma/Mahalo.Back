using Mahalo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahalo.Shared.DTOs
{
    public class TerapiesDto
    {
        public int Id { get; set; }

        public DateTime HourTerapy { get; set; }

        public string Name { get; set; } = null!;

        public bool IsActive { get; set; }

        public string CityName { get; set; } = null!;

        public int CityId { get; set; }

        public string PsychologistName { get; set; } = null!;

        public string PsychologistAddress { get; set; } = null!;

        public int PsychologistId { get; set; }

        
    }
}
