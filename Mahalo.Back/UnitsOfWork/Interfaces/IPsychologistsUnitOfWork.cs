using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;
using System.Threading.Tasks;

namespace Mahalo.Back.UnitsOfWork.Interfaces
{
    public interface IPsychologistsUnitOfWork
    {
        Task<ActionResponse<Psychologist>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<Psychologist>>> GetAsync();

        Task<IEnumerable<Psychologist>> GetComboAsync();

        Task<ActionResponse<IEnumerable<Psychologist>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
    }
}