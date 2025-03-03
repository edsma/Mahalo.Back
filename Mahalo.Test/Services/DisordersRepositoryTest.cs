using Mahalo.Back.Data;
using Mahalo.Back.Repositories.Implementation;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;
using Mahalo.Test.Mocks;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahalo.Test.Services
{
    public  class DisordersRepositoryTest: MahaloContextMock
    {
        private readonly Mock<DataContext> _context;
        private readonly DisordersRepository _repository;
        public DisordersRepositoryTest()
        {
            _context = GetDbContext();
            var result = CreateMockDbSet(DisordersMock.GetAllDisorders());

            _repository = new DisordersRepository(_context.Object);
            _context.Setup(x => x.Disorders).Returns(result.Object);
        }

        [Fact]
        public async Task GetByCodeSucess()
        {
            ActionResponse<Disorder> result = await _repository.GetAsync(1);
            Assert.True(result.MasSuccess);
        }

        [Fact]
        public async Task GetAll()
        {
            ActionResponse<IEnumerable<Disorder>> result = await _repository.GetAsync();
            Assert.True(result.MasSuccess);
        }
    }
}
