using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;

namespace Mahalo.Back.UnitsOfWork.Interfaces
{
    public interface IUsersUnitOfWork
    {
        Task<ActionResponse<User>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<User>>> GetAsync();

        Task<IEnumerable<User>> GetComboAsync();

        Task<ActionResponse<IEnumerable<User>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
    }
}