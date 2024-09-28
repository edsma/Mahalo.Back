using Mahalo.Back.Repositories.Interfaces;
using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;

namespace Mahalo.Back.UnitsOfWork.Implementation
{
    public class ResourcesUnitOfWork : GenericUnitOfWork<Resource>, IResourcesUnitOfWork
    {
        private readonly IResourcesRepository _ResourcesRepository;

        public ResourcesUnitOfWork(IGenericRepository<Resource> repository, IResourcesRepository ResourcesRepository) : base(repository)
        {
            _ResourcesRepository = ResourcesRepository;
        }

        public override async Task<ActionResponse<IEnumerable<Resource>>> GetAsync() => await _ResourcesRepository.GetAsync();

        public override async Task<ActionResponse<Resource>> GetAsync(int id) => await _ResourcesRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<Resource>>> GetAsync(PaginationDTO pagination) => await _ResourcesRepository.GetAsync(pagination);

        public async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await _ResourcesRepository.GetTotalRecordsAsync(pagination);

        public async Task<IEnumerable<Resource>> GetComboAsync() => await _ResourcesRepository.GetComboAsync();
    }
}