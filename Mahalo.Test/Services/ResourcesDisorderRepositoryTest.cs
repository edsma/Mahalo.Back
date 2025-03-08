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
    public class ResourcesDisorderRepositoryTest: MahaloContextMock
    {
        private readonly Mock<DataContext> _context;
        private readonly ResourcesDisorderRepository _repository;
        public ResourcesDisorderRepositoryTest()
        {
            _context = GetDbContext();
            var result = CreateMockDbSet(ResourceDisorderMock.GetAllResourceDosirders());

            _repository = new ResourcesDisorderRepository(_context.Object);
            _context.Setup(x => x.ResourcesDisorder).Returns(result.Object);
        }

        [Fact]
        public async Task GetByCodeSucess()
        {
            ActionResponse<ResourceDisorder> result = await _repository.GetAsync(1);
            Assert.True(result.MasSuccess);
        }

        [Fact]
        public async Task GetAll()
        {
            ActionResponse<IEnumerable<ResourceDisorder>> result = await _repository.GetAsync();
            Assert.True(result.MasSuccess);
        }
    }
}
