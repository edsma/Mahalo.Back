using Mahalo.Back.Repositories.Interfaces;
using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;

namespace Mahalo.Back.UnitsOfWork.Implementation
{
    public class StatesUnitOfWork : GenericUnitOfWork<State>, IStatesUnitOfWork
    {
        private readonly IStatesRepository _StatesRepository;

        public StatesUnitOfWork(IGenericRepository<State> repository, IStatesRepository StatesRepository) : base(repository)
        {
            _StatesRepository = StatesRepository;
        }

        public override async Task<ActionResponse<IEnumerable<State>>> GetAsync() => await _StatesRepository.GetAsync();

        public override async Task<ActionResponse<State>> GetAsync(int id) => await _StatesRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDTO pagination) => await _StatesRepository.GetAsync(pagination);

        public async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await _StatesRepository.GetTotalRecordsAsync(pagination);

        public async Task<IEnumerable<State>> GetComboAsync() => await _StatesRepository.GetComboAsync();
    }
}