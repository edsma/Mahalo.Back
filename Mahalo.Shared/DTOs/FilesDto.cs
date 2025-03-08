using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahalo.Shared.DTOs
{
    public class FilesDto
    {
        public string route { get; set; } = null!;
        public string name { get; set; } = null!;

        public bool resultProcess { get; set; }
    }
}
