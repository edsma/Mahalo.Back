using Mahalo.Back.Data;
using Mahalo.Back.Repositories.Implementation;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;
using Mahalo.Test.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahalo.Test.Services
{
    public class DocumentTypeRepositoryMock : MahaloContextMock
    {
        private readonly Mock<DataContext> _context;
        private readonly DocumentTypesRepository _repository;
        public DocumentTypeRepositoryMock()
        {

            _context = GetDbContext();
            var result = CreateMockDbSet(DocumentTypeMock.GetAllDocumentsTypes());

            _repository = new DocumentTypesRepository(_context.Object);
            _context.Setup(x => x.DocumentTypes).Returns(result.Object);
        }


        [Fact]
        public async Task GetByCodeSucess()
        {
            ActionResponse<DocumentType> result = await _repository.GetAsync(1);
            Assert.True(result.MasSuccess);
        }

        [Fact]
        public async Task GetAll()
        {
            ActionResponse<IEnumerable<DocumentType>> result = await _repository.GetAsync();
            Assert.True(result.MasSuccess);
        }
    }
}
