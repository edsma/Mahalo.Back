using Mahalo.Back.Data;
using Mahalo.Back.Helpers;
using Mahalo.Back.Repositories.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;
using Microsoft.EntityFrameworkCore;

namespace Mahalo.Back.Repositories.Implementation
{
    public class PsychologistsRepository : GenericRepository<Psychologist>, IPsychologistsRepository
    {
        private readonly DataContext _context;

        public PsychologistsRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<Psychologist>> GetAsync(int id)
        {
            var psychologist = await _context.Psychologists
                .Include(x => x.City)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (psychologist == null)
            {
                return new ActionResponse<Psychologist>
                {
                    MasSuccess = false,
                    Message = "ERR001"
                };
            }

            return new ActionResponse<Psychologist>
            {
                MasSuccess = true,
                Result = psychologist
            };
        }

        public override async Task<ActionResponse<IEnumerable<Psychologist>>> GetAsync()
        {
            var psychologists = await _context.Psychologists
                .Include(x => x.City)
                .ToListAsync();
            return new ActionResponse<IEnumerable<Psychologist>>
            {
                MasSuccess = true,
                Result = psychologists
            };
        }

        public async Task<IEnumerable<Psychologist>> GetComboAsync()
        {
            return await _context.Psychologists
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public override async Task<ActionResponse<IEnumerable<Psychologist>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Psychologists
                .Include(x => x.City)
                .OrderBy(x => x.Name)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return new ActionResponse<IEnumerable<Psychologist>>
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
            var queryable = _context.Psychologists.AsQueryable();

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