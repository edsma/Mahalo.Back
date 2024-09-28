using Mahalo.Back.Data;
using Mahalo.Back.Helpers;
using Mahalo.Back.Repositories.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;
using Microsoft.EntityFrameworkCore;

namespace Mahalo.Back.Repositories.Implementation
{
    public class ResourcesDisorderRepository : GenericRepository<ResourceDisorder>, IResourcesDisorderRepository
    {
        private readonly DataContext _context;

        public ResourcesDisorderRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<ResourceDisorder>> GetAsync(int id)
        {
            var resourceDisorder = await _context.ResourcesDisorder
                .FirstOrDefaultAsync(x => x.Id == id);

            if (resourceDisorder == null)
            {
                return new ActionResponse<ResourceDisorder>
                {
                    MasSuccess = false,
                    Message = "ERR001"
                };
            }

            return new ActionResponse<ResourceDisorder>
            {
                MasSuccess = true,
                Result = resourceDisorder
            };
        }

        public override async Task<ActionResponse<IEnumerable<ResourceDisorder>>> GetAsync()
        {
            var resourcesDisorder = await _context.ResourcesDisorder
                .ToListAsync();
            return new ActionResponse<IEnumerable<ResourceDisorder>>
            {
                MasSuccess = true,
                Result = resourcesDisorder
            };
        }

        public async Task<IEnumerable<ResourceDisorder>> GetComboAsync()
        {
            return await _context.ResourcesDisorder
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public override async Task<ActionResponse<IEnumerable<ResourceDisorder>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.ResourcesDisorder
                .OrderBy(x => x.Name)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return new ActionResponse<IEnumerable<ResourceDisorder>>
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
            var queryable = _context.ResourcesDisorder.AsQueryable();

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