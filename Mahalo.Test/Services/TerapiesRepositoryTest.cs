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
    public class TerapiesRepositoryTest: MahaloContextMock
    {
        private readonly Mock<DataContext> _context;
        private readonly TerapiesRepository _repository;
        public TerapiesRepositoryTest()
        {
            _context = GetDbContext();
            var result = CreateMockDbSet(TerapyMock.GetAllTerapies());

            _repository = new TerapiesRepository(_context.Object);
            _context.Setup(x => x.Terapies).Returns(result.Object);
        }

        [Fact]
        public async Task GetByCodeSucess()
        {
            ActionResponse<Terapy> result = await _repository.GetAsync(1);
            Assert.True(result.MasSuccess);
        }

        [Fact]
        public async Task GetAll()
        {
            ActionResponse<IEnumerable<Terapy>> result = await _repository.GetAsync();
            Assert.True(result.MasSuccess);
        }
    }
}
