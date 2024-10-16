﻿using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;
using Microsoft.AspNetCore.Identity;

namespace Mahalo.Back.UnitsOfWork.Interfaces
{
    public interface IUsersUnitOfWork
    {
        // Task<ActionResponse<User>> GetAsync(int id);

        //Task<ActionResponse<IEnumerable<User>>> GetAsync();

        //Task<IEnumerable<User>> GetComboAsync();

        //Task<ActionResponse<IEnumerable<User>>> GetAsync(PaginationDTO pagination);

        //Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);

        //
        Task<User> GetUserAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);
    }
}