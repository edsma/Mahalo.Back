using Mahalo.Back.Repositories.Interfaces;
using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;

namespace Mahalo.Back.UnitsOfWork.Implementation
{
    public class TerapiesUnitOfWork : GenericUnitOfWork<Terapy>, ITerapiesUnitOfWork
    {
        private readonly ITerapiesRepository _TerapiesRepository;

        public TerapiesUnitOfWork(IGenericRepository<Terapy> repository, ITerapiesRepository TerapiesRepository) : base(repository)
        {
            _TerapiesRepository = TerapiesRepository;
        }

        public override async Task<ActionResponse<IEnumerable<Terapy>>> GetAsync() => await _TerapiesRepository.GetAsync();

        public override async Task<ActionResponse<Terapy>> GetAsync(int id) => await _TerapiesRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<Terapy>>> GetAsync(PaginationDTO pagination) => await _TerapiesRepository.GetAsync(pagination);

        public async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await _TerapiesRepository.GetTotalRecordsAsync(pagination);

        public async Task<IEnumerable<Terapy>> GetComboAsync() => await _TerapiesRepository.GetComboAsync();
    }
}