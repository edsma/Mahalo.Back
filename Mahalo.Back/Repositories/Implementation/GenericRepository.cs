using Mahalo.Back.Data;
using Mahalo.Back.Helpers;
using Mahalo.Back.Repositories.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Response;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Mahalo.Back.Repositories.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<T> _entity;

        public GenericRepository(DataContext context)
        {
            _dataContext = context;
            _entity = context.Set<T>();
        }

        public virtual async Task<ActionResponse<T>> AddAsync(T entity)
        {
            _dataContext.Add(entity);
            try
            {
                await _dataContext.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse();
            }
            catch (Exception exception)
            {
                return ExceptionActionResponse(exception);
            }
        }

        private ActionResponse<T> ExceptionActionResponse(Exception ex)
        {
            return new ActionResponse<T>
            {
                WasSuccess = false,
                Message = ex.Message,
            };
        }

        private ActionResponse<T> DbUpdateExceptionActionResponse()
        {
            return new ActionResponse<T>
            {
                WasSuccess = false,
                Message = "ERR003"
            };
        }

        public virtual async Task<ActionResponse<T>> DeleteAsync(int id)
        {
            var row = await _entity.FindAsync(id);
            if (row == null)
            {
                return new ActionResponse<T>
                {
                    WasSuccess = false,
                    Message = "ERR001"
                };
            }

            try
            {
                _entity.Remove(row);
                await _dataContext.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                };
            }
            catch
            {
                return new ActionResponse<T>
                {
                    WasSuccess = false,
                    Message = "ERR002"
                };
            }
        }

        public virtual async Task<ActionResponse<T>> GetAsync(int id)
        {
            var row = await _entity.FindAsync(id);
            if (row != null)
            {
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Result = row
                };
            }
            return new ActionResponse<T>
            {
                WasSuccess = false,
                Message = "ERR001"
            };
        }

        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync()
        {
            return new ActionResponse<IEnumerable<T>>
            {
                WasSuccess = true,
                Result = await _entity.ToListAsync()
            };
        }

        public virtual async Task<ActionResponse<T>> UpdateAsync(T entity)
        {
            try
            {
                _dataContext.Update(entity);
                await _dataContext.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse();
            }
            catch (Exception exception)
            {
                return ExceptionActionResponse(exception);
            }
        }

        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _entity.AsQueryable();

            return new ActionResponse<IEnumerable<T>>
            {
                WasSuccess = true,
                Result = await queryable
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }

        public virtual async Task<ActionResponse<int>> GetTotalRecordsAsync()
        {
            var queryable = _entity.AsQueryable();
            double count = await queryable.CountAsync();
            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = (int)count
            };
        }
    }
}