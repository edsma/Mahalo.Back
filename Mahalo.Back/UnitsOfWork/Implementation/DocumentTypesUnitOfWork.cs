using Mahalo.Back.Repositories.Interfaces;
using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;

namespace Mahalo.Back.UnitsOfWork.Implementation
{
    public class DocumentTypesUnitOfWork : GenericUnitOfWork<DocumentType>, IDocumentTypesUnitOfWork
    {
        private readonly IDocumentTypesRepository _documentTypesRepository;

        public DocumentTypesUnitOfWork(IGenericRepository<DocumentType> repository, IDocumentTypesRepository documentTypesRepository) : base(repository)
        {
            _documentTypesRepository = documentTypesRepository;
        }

        public override async Task<ActionResponse<IEnumerable<DocumentType>>> GetAsync() => await _documentTypesRepository.GetAsync();

        public override async Task<ActionResponse<DocumentType>> GetAsync(int id) => await _documentTypesRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<DocumentType>>> GetAsync(PaginationDTO pagination) => await _documentTypesRepository.GetAsync(pagination);

        public async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await _documentTypesRepository.GetTotalRecordsAsync(pagination);

        public async Task<IEnumerable<DocumentType>> GetComboAsync() => await _documentTypesRepository.GetComboAsync();
    }
}