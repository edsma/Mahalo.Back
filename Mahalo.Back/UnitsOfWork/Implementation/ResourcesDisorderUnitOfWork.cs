using Mahalo.Back.Repositories.Implementation;
using Mahalo.Back.Repositories.Interfaces;
using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;

namespace Mahalo.Back.UnitsOfWork.Implementation
{
    public class ResourcesDisorderUnitOfWork : GenericUnitOfWork<ResourceDisorder>, IResourcesDisorderUnitOfWork
    {
        private readonly IResourcesDisorderRepository _ResourcesDisorderRepository;

        public ResourcesDisorderUnitOfWork(IGenericRepository<ResourceDisorder> repository, IResourcesDisorderRepository ResourcesDisorderRepository) : base(repository)
        {
            _ResourcesDisorderRepository = ResourcesDisorderRepository;
        }

        public override async Task<ActionResponse<IEnumerable<ResourceDisorder>>> GetAsync() => await _ResourcesDisorderRepository.GetAsync();

        public override async Task<ActionResponse<ResourceDisorder>> GetAsync(int id) => await _ResourcesDisorderRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<ResourceDisorder>>> GetAsync(PaginationDTO pagination) => await _ResourcesDisorderRepository.GetAsync(pagination);

        public async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await _ResourcesDisorderRepository.GetTotalRecordsAsync(pagination);

        public async Task<IEnumerable<ResourceDisorder>> GetComboAsync() => await _ResourcesDisorderRepository.GetComboAsync();
    }
}