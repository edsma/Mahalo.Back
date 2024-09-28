using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;

namespace Mahalo.Back.UnitsOfWork.Interfaces
{
    public interface ITerapiesUnitOfWork
    {
        Task<ActionResponse<Terapy>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<Terapy>>> GetAsync();

        Task<IEnumerable<Terapy>> GetComboAsync();

        Task<ActionResponse<IEnumerable<Terapy>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
    }
}