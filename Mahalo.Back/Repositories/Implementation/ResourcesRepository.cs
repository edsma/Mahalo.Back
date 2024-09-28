using Mahalo.Back.Data;
using Mahalo.Back.Helpers;
using Mahalo.Back.Repositories.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;
using Microsoft.EntityFrameworkCore;

namespace Mahalo.Back.Repositories.Implementation
{
    public class ResourcesRepository : GenericRepository<Resource>, IResourcesRepository
    {
        private readonly DataContext _context;

        public ResourcesRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<Resource>> GetAsync(int id)
        {
            var resource = await _context.Resources
                .FirstOrDefaultAsync(x => x.Id == id);

            if (resource == null)
            {
                return new ActionResponse<Resource>
                {
                    MasSuccess = false,
                    Message = "ERR001"
                };
            }

            return new ActionResponse<Resource>
            {
                MasSuccess = true,
                Result = resource
            };
        }

        public override async Task<ActionResponse<IEnumerable<Resource>>> GetAsync()
        {
            var resources = await _context.Resources
                .ToListAsync();
            return new ActionResponse<IEnumerable<Resource>>
            {
                MasSuccess = true,
                Result = resources
            };
        }

        public async Task<IEnumerable<Resource>> GetComboAsync()
        {
            return await _context.Resources
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public override async Task<ActionResponse<IEnumerable<Resource>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Resources
                .OrderBy(x => x.Name)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return new ActionResponse<IEnumerable<Resource>>
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
            var queryable = _context.Resources.AsQueryable();

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