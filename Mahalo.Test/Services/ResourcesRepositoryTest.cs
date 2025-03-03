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
    public class ResourcesRepositoryTest: MahaloContextMock
    {
        private readonly Mock<DataContext> _context;
        private readonly ResourcesRepository _repository;
        public ResourcesRepositoryTest()
        {
            _context = GetDbContext();
            var result = CreateMockDbSet(ResourcesRepositoryMock.GetAllResourcesRepository());

            _repository = new ResourcesRepository(_context.Object);
            _context.Setup(x => x.Resources).Returns(result.Object);
        }

        [Fact]
        public async Task GetByCodeSucess()
        {
            ActionResponse<Resource> result = await _repository.GetAsync(1);
            Assert.True(result.MasSuccess);
        }

        [Fact]
        public async Task GetAll()
        {
            ActionResponse<IEnumerable<Resource>> result = await _repository.GetAsync();
            Assert.True(result.MasSuccess);
        }
    }
}
