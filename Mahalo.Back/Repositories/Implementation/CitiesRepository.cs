using Mahalo.Back.Data;
using Mahalo.Back.Helpers;
using Mahalo.Back.Repositories.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;
using Microsoft.EntityFrameworkCore;

namespace Mahalo.Back.Repositories.Implementation
{
    public class CitiesRepository : GenericRepository<City>, ICitiesRepository
    {
        private readonly DataContext _context;

        public CitiesRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<City>> GetAsync(int id)
        {
            var city = await _context.Cities
                .FirstOrDefaultAsync(x => x.Id == id);

            if (city == null)
            {
                return new ActionResponse<City>
                {
                    MasSuccess = false,
                    Message = "ERR001"
                };
            }

            return new ActionResponse<City>
            {
                MasSuccess = true,
                Result = city
            };
        }

        public override async Task<ActionResponse<IEnumerable<City>>> GetAsync()
        {
            var cities = await _context.Cities
                .ToListAsync();
            return new ActionResponse<IEnumerable<City>>
            {
                MasSuccess = true,
                Result = cities
            };
        }

        public async Task<IEnumerable<City>> GetComboAsync()
        {
            return await _context.Cities
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public override async Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Cities
                .OrderBy(x => x.Name)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return new ActionResponse<IEnumerable<City>>
            {
                WasSuccess = true,
                Result = await queryable
                    .OrderBy(x => x.Name)
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }

        public async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
        {
            var queryable = _context.Cities.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.Contains(pagination.Filter, StringComparison.CurrentCultureIgnoreCase));
            }

            double count = await queryable.CountAsync();
            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = (int)count
            };
        }
    }
}