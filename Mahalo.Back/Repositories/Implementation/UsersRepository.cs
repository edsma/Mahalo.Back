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
using Microsoft.AspNetCore.Identity;

namespace Mahalo.Back.Repositories.Implementation
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public UsersRepository(DataContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<ActionResponse<IEnumerable<User>>> GetAsync()
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
                .OrderBy(x => x.FullName)
                .ToListAsync();
        }

        public async Task<ActionResponse<IEnumerable<User>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Users
                .Include(x => x.City)
                .OrderBy(x => x.FullName)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.FullName.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return new ActionResponse<IEnumerable<User>>
            {
                WasSuccess = true,
                Result = await queryable
                    .OrderBy(x => x.FullName)
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }

        public async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
        {
            var queryable = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.FullName.Contains(pagination.Filter, StringComparison.CurrentCultureIgnoreCase));
            }

            double count = await queryable.CountAsync();
            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = (int)count
            };
        }

        //

        public async Task<User> GetUserAsync(Guid userId)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Id == userId.ToString());
            return user!;
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(User user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<IdentityResult> ConfirmEmailAsync(User user, string token)
        {
            return await _userManager.ConfirmEmailAsync(user, token);
        }

        public async Task<SignInResult> LoginAsync(LoginDTO model)
        {
            return await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, true);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task<User> GetUserAsync(string email)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == email);
            return user!;
        }

        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(User user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<IdentityResult> ResetPasswordAsync(User user, string token, string password)
        {
            return await _userManager.ResetPasswordAsync(user, token, password);
        }
    }
}