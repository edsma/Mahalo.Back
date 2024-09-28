using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;

namespace Mahalo.Back.Repositories.Interfaces
{
    public interface IPsychologistsRepository
    {
        Task<ActionResponse<Psychologist>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<Psychologist>>> GetAsync();

        Task<IEnumerable<Psychologist>> GetComboAsync();

        Task<ActionResponse<IEnumerable<Psychologist>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
    }
}