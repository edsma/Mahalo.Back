using Mahalo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahalo.Test.Mocks
{
    public static class DisordersMock
    {
        public static List<Disorder> GetAllDisorders()
        {
            return new List<Disorder>
            {
               new Disorder
               {
                    Id = 1,
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    Name = "Pereza"
               }
            };
        }
    }
}
