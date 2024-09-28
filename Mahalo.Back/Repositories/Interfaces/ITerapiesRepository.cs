using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;

namespace Mahalo.Back.Repositories.Interfaces
{
    public interface ITerapiesRepository
    {
        Task<ActionResponse<Terapy>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<Terapy>>> GetAsync();

        Task<IEnumerable<Terapy>> GetComboAsync();

        Task<ActionResponse<IEnumerable<Terapy>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
    }
}