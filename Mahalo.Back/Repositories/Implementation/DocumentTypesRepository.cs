using Mahalo.Back.Data;
using Mahalo.Back.Helpers;
using Mahalo.Back.Repositories.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;
using Microsoft.EntityFrameworkCore;

namespace Mahalo.Back.Repositories.Implementation
{
    public class DocumentTypesRepository : GenericRepository<DocumentType>, IDocumentTypesRepository
    {
        private readonly DataContext _context;

        public DocumentTypesRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<DocumentType>> GetAsync(int id)
        {
            var documenttype = await _context.DocumentTypes
                .FirstOrDefaultAsync(x => x.Id == id);

            if (documenttype == null)
            {
                return new ActionResponse<DocumentType>
                {
                    MasSuccess = false,
                    Message = "ERR001"
                };
            }

            return new ActionResponse<DocumentType>
            {
                MasSuccess = true,
                Result = documenttype
            };
        }

        public override async Task<ActionResponse<IEnumerable<DocumentType>>> GetAsync()
        {
            var documenttypes = await _context.DocumentTypes
                .ToListAsync();
            return new ActionResponse<IEnumerable<DocumentType>>
            {
                MasSuccess = true,
                Result = documenttypes
            };
        }

        public async Task<IEnumerable<DocumentType>> GetComboAsync()
        {
            return await _context.DocumentTypes
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public override async Task<ActionResponse<IEnumerable<DocumentType>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.DocumentTypes
                .OrderBy(x => x.Name)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return new ActionResponse<IEnumerable<DocumentType>>
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
            var queryable = _context.Countries.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.Contains(pagination.Filter));
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