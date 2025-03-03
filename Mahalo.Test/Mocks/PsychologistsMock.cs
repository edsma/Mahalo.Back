using Mahalo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahalo.Test.Mocks
{
    public static class PsychologistsMock
    {
        public static List<Psychologist> GetAllPsychologistsMock()
        {
            return new List<Psychologist>
            {
               new Psychologist
               {
                    Id = 1,
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    Name = "Azeroth",
                    
               }
            };
        }
    }
}
