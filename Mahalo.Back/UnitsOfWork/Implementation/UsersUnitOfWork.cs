﻿using Mahalo.Back.Repositories.Interfaces;
using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;

namespace Mahalo.Back.UnitsOfWork.Implementation
{
    public class UsersUnitOfWork : GenericUnitOfWork<User>, IUsersUnitOfWork
    {
        private readonly IUsersRepository _UsersRepository;

        public UsersUnitOfWork(IGenericRepository<User> repository, IUsersRepository UsersRepository) : base(repository)
        {
            _UsersRepository = UsersRepository;
        }

        public override async Task<ActionResponse<IEnumerable<User>>> GetAsync() => await _UsersRepository.GetAsync();

        public override async Task<ActionResponse<User>> GetAsync(int id) => await _UsersRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<User>>> GetAsync(PaginationDTO pagination) => await _UsersRepository.GetAsync(pagination);

        public async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await _UsersRepository.GetTotalRecordsAsync(pagination);

        public async Task<IEnumerable<User>> GetComboAsync() => await _UsersRepository.GetComboAsync();
    }
}