using Mahalo.Back.Data;
using Mahalo.Back.Repositories.Interfaces;
using Mahalo.Shared.DTOs;

using Mahalo.Back.Data;

using Mahalo.Back.Helpers;

using Mahalo.Back.Repositories.Interfaces;
using Mahalo.Shared.DTOs;

using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;
using Microsoft.EntityFrameworkCore;

namespace Mahalo.Back.Repositories.Implementation
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        private readonly DataContext _context;

        public UsersRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<User>> GetAsync(int id)
        {
            var user = await _context.Users
                .Include(x => x.City)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return new ActionResponse<User>
                {
                    MasSuccess = false,
                    Message = "ERR001"
                };
            }

            return new ActionResponse<User>
            {
                MasSuccess = true,
                Result = user
            };
        }

        public override async Task<ActionResponse<IEnumerable<User>>> GetAsync()
        {
            var users = await _context.Users
                .Include(x => x.City)
                .ToListAsync();
            return new ActionResponse<IEnumerable<User>>
            {
                MasSuccess = true,
                Result = users
            };
        }

        public async Task<IEnumerable<User>> GetComboAsync()
        {
            return await _context.Users
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public override async Task<ActionResponse<IEnumerable<User>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Users
                .Include(x => x.City)
                .OrderBy(x => x.Name)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return new ActionResponse<IEnumerable<User>>
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
            var queryable = _context.Users.AsQueryable();

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