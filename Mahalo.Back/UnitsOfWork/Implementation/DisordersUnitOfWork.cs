using Mahalo.Back.Repositories.Implementation;
using Mahalo.Back.Repositories.Interfaces;
using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;

namespace Mahalo.Back.UnitsOfWork.Implementation
{
    public class DisordersUnitOfWork : GenericUnitOfWork<Disorder>, IDisordersUnitOfWork
    {
        private readonly IDisordersRepository _disordersRepository;

        public DisordersUnitOfWork(IGenericRepository<Disorder> repository, IDisordersRepository disordersRepository) : base(repository)
        {
            _disordersRepository = disordersRepository;
        }

        public override async Task<ActionResponse<IEnumerable<Disorder>>> GetAsync() => await _disordersRepository.GetAsync();

        public override async Task<ActionResponse<Disorder>> GetAsync(int id) => await _disordersRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<Disorder>>> GetAsync(PaginationDTO pagination) => await _disordersRepository.GetAsync(pagination);

        public async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await _disordersRepository.GetTotalRecordsAsync(pagination);

        public async Task<IEnumerable<Disorder>> GetComboAsync() => await _disordersRepository.GetComboAsync();
    }
}