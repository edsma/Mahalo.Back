using Mahalo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahalo.Test.Mocks
{
    public static class TerapyMock
    {
        public static List<Terapy> GetAllTerapies()
        {
            return new List<Terapy>
            {
               new Terapy
               {
                    Id = 1,
                    HourTerapy = DateTime.Now,
                    IsActive = true,
                    Name = "Azeroth",

               }
            };
        }
    }
}
