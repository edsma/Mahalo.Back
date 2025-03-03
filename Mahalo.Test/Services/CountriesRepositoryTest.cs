using Mahalo.Back.Data;
using Mahalo.Back.Repositories.Implementation;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;
using Mahalo.Test.Mocks;
using Moq;

namespace Mahalo.Test.Services
{
    public class CountriesRepositoryTest : MahaloContextMock
    {

        private readonly Mock<DataContext> _context;
        private readonly CountriesRepository _repository;
        public CountriesRepositoryTest()
        {

            _context = GetDbContext();
            var result = CreateMockDbSet(CountriesMock.GetAllCountries());

            _repository = new CountriesRepository(_context.Object);
            _context.Setup(x => x.Countries).Returns(result.Object);
        }


        [Fact]
        public async Task GetByCodeSucess()
        {
            ActionResponse<Country> result = await _repository.GetAsync(1);
            Assert.True(result.MasSuccess);
        }

        [Fact]
        public async Task GetAll()
        {
            ActionResponse<IEnumerable<Country>> result = await _repository.GetAsync();
            Assert.True(result.MasSuccess);
        }
    }
}
