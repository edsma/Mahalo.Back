using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;

namespace Mahalo.Back.UnitsOfWork.Interfaces
{
    public interface IDisordersUnitOfWork
    {
        Task<ActionResponse<Disorder>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<Disorder>>> GetAsync();

        Task<IEnumerable<Disorder>> GetComboAsync();

        Task<ActionResponse<IEnumerable<Disorder>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
    }
}