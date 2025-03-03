using Mahalo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahalo.Test.Mocks
{
    public static class ResourceDisorderMock
    {
        public static List<ResourceDisorder> GetAllResourceDosirders()
        {
            return new List<ResourceDisorder>
            {
               new ResourceDisorder
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
