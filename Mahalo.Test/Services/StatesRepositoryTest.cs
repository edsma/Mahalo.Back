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
    public class StatesRepositoryTest: MahaloContextMock
    {
        private readonly Mock<DataContext> _context;
        private readonly StatesRepository _repository;
        public StatesRepositoryTest()
        {
            _context = GetDbContext();
            var result = CreateMockDbSet(StatesMock.GetAllStates());

            _repository = new StatesRepository(_context.Object);
            _context.Setup(x => x.States).Returns(result.Object);
        }

        [Fact]
        public async Task GetByCodeSucess()
        {
            ActionResponse<State> result = await _repository.GetAsync(1);
            Assert.True(result.MasSuccess);
        }

        [Fact]
        public async Task GetAll()
        {
            ActionResponse<IEnumerable<State>> result = await _repository.GetAsync();
            Assert.True(result.MasSuccess);
        }
    }
}
