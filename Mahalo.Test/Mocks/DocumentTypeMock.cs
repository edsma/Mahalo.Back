using Mahalo.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahalo.Test.Mocks
{
    public static class DocumentTypeMock
    {
        public static List<DocumentType> GetAllDocumentsTypes()
        {
            return new List<DocumentType>
            {
               new DocumentType
               {
                    Id = 1,
                    IsActive = true,
                    Name = "Azeroth",
                    Abbreviation = "A"
               }
            };
        }
    }
}
