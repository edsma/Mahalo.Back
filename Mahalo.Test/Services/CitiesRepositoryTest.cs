using Mahalo.Back.Data;
using Mahalo.Back.Repositories.Implementation;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;
using Mahalo.Test.Mocks;
using Moq;

namespace Mahalo.Test.Services
{
    public class CitiesRepositoryTest : MahaloContextMock
    {
        private readonly Mock<DataContext> _context;
        private readonly CitiesRepository _repository;
        public CitiesRepositoryTest()
        {
            _context = GetDbContext();
            var result = CreateMockDbSet(CitiesMock.GetAllCities());

            _repository = new CitiesRepository(_context.Object);
            _context.Setup(x => x.Cities).Returns(result.Object);
        }

        [Fact]
        public async Task GetByCodeSucess()
        {
            ActionResponse<City> result = await _repository.GetAsync(1);
            Assert.True(result.MasSuccess);
        }

        [Fact]
        public async Task GetAll()
        {
            ActionResponse<IEnumerable<City>> result = await _repository.GetAsync();
            Assert.True(result.MasSuccess);
        }




    }
}
