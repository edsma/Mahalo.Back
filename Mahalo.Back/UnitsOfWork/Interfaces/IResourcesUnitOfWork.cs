using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;

namespace Mahalo.Back.UnitsOfWork.Interfaces
{
    public interface IResourcesUnitOfWork
    {
        Task<ActionResponse<Resource>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<Resource>>> GetAsync();

        Task<IEnumerable<Resource>> GetComboAsync();

        Task<ActionResponse<IEnumerable<Resource>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
    }
}