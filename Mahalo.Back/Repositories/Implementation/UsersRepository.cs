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
        private readonly IFileStorage _fileStorage;

        public UsersRepository(DataContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, IFileStorage fileStorage)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _fileStorage = fileStorage;
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
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<ActionResponse<IEnumerable<User>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Users
                .Include(x => x.City)
                .OrderBy(x => x.Id)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.FullName.ToLower().Contains(pagination.Filter.ToLower()));
            }

            return new ActionResponse<IEnumerable<User>>
            {
                WasSuccess = true,
                Result = await queryable
                    .OrderBy(x => x.Id)
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }

        public async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
        {
            var queryable = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.FullName.Contains(pagination.Filter));
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
            if (!string.IsNullOrEmpty(user.Photo))
            {
                var imageBase64 = Convert.FromBase64String(user.Photo!);
                user.Photo = await _fileStorage.SaveFileAsync(imageBase64, ".jpg", "users");
            }

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
            if (!string.IsNullOrEmpty(user.Photo))
            {
                //var imageBase64 = Convert.FromBase64String(user.Photo!);
                //user.Photo = await _fileStorage.SaveFileAsync(imageBase64, ".jpg", "users");
            }
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