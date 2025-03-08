using Mahalo.Back.Repositories.Implementation;
using Mahalo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahalo.Test.Mocks
{
    public static class ResourcesRepositoryMock
    {
        public static List<Resource> GetAllResourcesRepository()
        {
            return new List<Resource>
            {
               new Resource
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
