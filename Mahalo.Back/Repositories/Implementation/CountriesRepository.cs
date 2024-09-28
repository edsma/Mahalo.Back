using Mahalo.Back.Data;
using Mahalo.Back.Helpers;
using Mahalo.Back.Repositories.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Response;
using Microsoft.EntityFrameworkCore;

namespace Mahalo.Back.Repositories.Implementation;

public class CountriesRepository : GenericRepository<Country>, ICountriesRepository
{
    private readonly DataContext _context;

    public CountriesRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    //public override async Task<ActionResponse<Country>> GetAsync(int id)
    //{
    //    var country = await _context.Countries
    //        .Include(x => x.State)
    //        .FirstOrDefaultAsync(x => x.Id == id);

    //    if (country == null)
    //    {
    //        return new ActionResponse<Country>
    //        {
    //            MasSuccess = false,
    //            Message = "ERR001"
    //        };
    //    }

    //    return new ActionResponse<Country>
    //    {
    //        MasSuccess = true,
    //        Result = country
    //    };
    //}

    //public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync()
    //{
    //    var countries = await _context.Countries
    //        .Include(x => x.Teams)
    //        .ToListAsync();
    //    return new ActionResponse<IEnumerable<Country>>
    //    {
    //        MasSuccess = true,
    //        Result = countries
    //    };
    //}

    public async Task<IEnumerable<Country>> GetComboAsync()
    {
        return await _context.Countries
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    //public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination)
    //{
    //    var queryable = _context.Countries
    //        .Include(x => x.Teams)
    //        .OrderBy(x => x.Name)
    //        .AsQueryable();

    //    if (!string.IsNullOrWhiteSpace(pagination.Filter))
    //    {
    //        queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
    //    }

    //    return new ActionResponse<IEnumerable<Country>>
    //    {
    //        WasSuccess = true,
    //        Result = await queryable
    //            .OrderBy(x => x.Name)
    //            .Paginate(pagination)
    //            .ToListAsync()
    //    };
    //}

    public async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
    {
        var queryable = _context.Countries.AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            queryable = queryable.Where(x => x.Name.Contains(pagination.Filter, StringComparison.CurrentCultureIgnoreCase));
        }

        double count = await queryable.CountAsync();
        return new ActionResponse<int>
        {
            WasSuccess = true,
            Result = (int)count
        };
    }
}