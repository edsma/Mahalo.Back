using Mahalo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahalo.Shared.DTOs
{
    public class CityDto
    {
        public int Id { get; set; }

     
        public string Name { get; set; } = null!;

        public bool IsActive { get; set; }

  
        public DateTime CreationDate { get; set; }

        public StateDto State { get; set; } = null!;
    }
}
