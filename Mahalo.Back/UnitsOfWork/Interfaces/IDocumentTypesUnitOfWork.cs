using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;

namespace Mahalo.Back.UnitsOfWork.Interfaces
{
    public interface IDocumentTypesUnitOfWork
    {
        Task<ActionResponse<DocumentType>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<DocumentType>>> GetAsync();

        Task<IEnumerable<DocumentType>> GetComboAsync();

        Task<ActionResponse<IEnumerable<DocumentType>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);
    }
}