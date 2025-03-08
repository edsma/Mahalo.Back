using Mahalo.Back.Repositories.Interfaces;
using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;

namespace Mahalo.Back.UnitsOfWork.Implementation
{
    public class PsychologistsUnitOfWork : GenericUnitOfWork<Psychologist>, IPsychologistsUnitOfWork
    {
        private readonly IPsychologistsRepository _PsychologistsRepository;

        public PsychologistsUnitOfWork(IGenericRepository<Psychologist> repository, IPsychologistsRepository PsychologistsRepository) : base(repository)
        {
            _PsychologistsRepository = PsychologistsRepository;
        }

        public override async Task<ActionResponse<IEnumerable<Psychologist>>> GetAsync() => await _PsychologistsRepository.GetAsync();

        public override async Task<ActionResponse<Psychologist>> GetAsync(int id) => await _PsychologistsRepository.GetAsync(id);

        public override async Task<ActionResponse<IEnumerable<Psychologist>>> GetAsync(PaginationDTO pagination) => await _PsychologistsRepository.GetAsync(pagination);

        public async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await _PsychologistsRepository.GetTotalRecordsAsync(pagination);

        public async Task<IEnumerable<Psychologist>> GetComboAsync() => await _PsychologistsRepository.GetComboAsync();
    }
}