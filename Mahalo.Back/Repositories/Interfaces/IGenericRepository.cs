﻿using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;

namespace Mahalo.Back.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<ActionResponse<T>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<T>>> GetAsync();

    Task<ActionResponse<T>> AddAsync(T entity);

    Task<ActionResponse<T>> DeleteAsync(int id);

    Task<ActionResponse<T>> UpdateAsync(T entity);

    Task<ActionResponse<IEnumerable<T>>> GetAsync(PaginationDTO pagination);

    Task<ActionResponse<int>> GetTotalRecordsAsync();


}