using Mahalo.Back.Data;
using Mahalo.Back.Helpers;
using Mahalo.Back.Repositories.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;
using Microsoft.EntityFrameworkCore;

namespace Mahalo.Back.Repositories.Implementation
{
    public class DisordersRepository : GenericRepository<Disorder>, IDisordersRepository
    {
        private readonly DataContext _context;

        public DisordersRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<Disorder>> GetAsync(int id)
        {
            var Disorder = await _context.Disorders
                .FirstOrDefaultAsync(x => x.Id == id);

            if (Disorder == null)
            {
                return new ActionResponse<Disorder>
                {
                    MasSuccess = false,
                    Message = "ERR001"
                };
            }

            return new ActionResponse<Disorder>
            {
                MasSuccess = true,
                Result = Disorder
            };
        }

        public override async Task<ActionResponse<IEnumerable<Disorder>>> GetAsync()
        {
            var disorders = await _context.Disorders
                .ToListAsync();
            return new ActionResponse<IEnumerable<Disorder>>
            {
                MasSuccess = true,
                Result = disorders
            };
        }

        public async Task<IEnumerable<Disorder>> GetComboAsync()
        {
            return await _context.Disorders
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public override async Task<ActionResponse<IEnumerable<Disorder>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Disorders
                .OrderBy(x => x.Name)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return new ActionResponse<IEnumerable<Disorder>>
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
            var queryable = _context.Disorders.AsQueryable();

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