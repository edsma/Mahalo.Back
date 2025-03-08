using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahalo.Shared.DTOs
{
    public class ResourceDto
    {
        public IFormFile file { get; set; } = null!;

        public int ResourceDisorderId { get; set; }
        public int ResourceId { get; set; }
        public string ResourceDisorderName { get; set; } = null!;

        public string FileName { get; set; } = null!;


        public string FileDescription { get; set; } = null!;
    }
}
