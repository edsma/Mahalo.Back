using Mahalo.Back.Data;
using Mahalo.Back.Repositories.Implementation;
using Mahalo.Back.Repositories.Interfaces;
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
    public class GenericRepositoryTest: MahaloContextMock
    {
        private readonly Mock<DataContext> _context;
        private  GenericRepository<City> _repository;
        public GenericRepositoryTest()
        {
            _context = GetDbContext();

        }

        [Fact]
        public async Task AddAsync()
        {


            var resultDto = CreateMockDbSet(CitiesMock.GetAllCities());

            // Asegurar que `DbSet<City>` esté correctamente configurado en `DataContext`
            _context.Setup(c => c.Set<City>()).Returns(resultDto.Object);

            // Opcional: Configurar directamente la propiedad `Cities` si existe en `DataContext`
            _context.Setup(c => c.Cities).Returns(resultDto.Object);



            _repository = new GenericRepository<City>(_context.Object);
            ActionResponse<City> result = await _repository.AddAsync(new City { Id = 1, Name = "test", IsActive = true, CreationDate = DateTime.Now });
            Assert.True(result.WasSuccess);
        }

        [Fact]
        public async Task DbUpdateExceptionActionResponse()
        {


            var resultDto = CreateMockDbSet(CitiesMock.GetAllCities());

            // Asegurar que `DbSet<City>` esté correctamente configurado en `DataContext`
            _context.Setup(c => c.Set<City>()).Returns(resultDto.Object);

            // Opcional: Configurar directamente la propiedad `Cities` si existe en `DataContext`
            _context.Setup(c => c.Cities).Returns(resultDto.Object);


            _context.Setup(m => m.Set<City>().FindAsync(1)).ReturnsAsync(new City { Id = 1, Name = "test", IsActive = true, CreationDate = DateTime.Now });

            _repository = new GenericRepository<City>(_context.Object);
            ActionResponse<City> result = await _repository.GetAsync(1);
            Assert.True(result.WasSuccess);
        }


        [Fact]
        public async Task GetAllAsync()
        {


            var resultDto = CreateMockDbSet(CitiesMock.GetAllCities());

            // Asegurar que `DbSet<City>` esté correctamente configurado en `DataContext`
            _context.Setup(c => c.Set<City>()).Returns(resultDto.Object);

            // Opcional: Configurar directamente la propiedad `Cities` si existe en `DataContext`
            _context.Setup(c => c.Cities).Returns(resultDto.Object);


            _context.Setup(m => m.Set<City>().FindAsync(1)).ReturnsAsync(new City { Id = 1, Name = "test", IsActive = true, CreationDate = DateTime.Now });

            _repository = new GenericRepository<City>(_context.Object);
            ActionResponse<IEnumerable<City>> result = await _repository.GetAsync();
            Assert.True(result.WasSuccess);
        }




        [Fact]
        public async Task Delete()
        {


            var resultDto = CreateMockDbSet(CitiesMock.GetAllCities());

            // Asegurar que `DbSet<City>` esté correctamente configurado en `DataContext`
            _context.Setup(c => c.Set<City>()).Returns(resultDto.Object);

            // Opcional: Configurar directamente la propiedad `Cities` si existe en `DataContext`
            _context.Setup(c => c.Cities).Returns(resultDto.Object);

            _context.Setup(m => m.Set<City>().FindAsync(1)).ReturnsAsync(new City { Id = 1, Name = "test", IsActive = true, CreationDate = DateTime.Now });


            _repository = new GenericRepository<City>(_context.Object);
            ActionResponse<City> result = await _repository.DeleteAsync(1);
            Assert.True(result.WasSuccess);
        }

    }
}
