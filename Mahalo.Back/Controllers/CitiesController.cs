using Mahalo.Back.UnitsOfWork.Implementation;
using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Mahalo.Back.Controllers;

[ApiController]

[Route("api/[controller]")]
public class CitiesController : GenericController<City>
{
    private readonly ICitiesUnitOfWork _citiesUnitOfWork;
    private readonly IStatesUnitOfWork _statesUnitOfWork;
    private readonly IGenericUnitOfWork<City> _UnitOfWork;

    public CitiesController(IGenericUnitOfWork<City> unitOfWork, ICitiesUnitOfWork citiesUnitOfWork, IStatesUnitOfWork statesUnitOfWork) : base(unitOfWork)
    {
        _citiesUnitOfWork = citiesUnitOfWork;
        _UnitOfWork = unitOfWork;
        _statesUnitOfWork = statesUnitOfWork;
    }

    [HttpGet("paginated")]
    public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
    {
        var response = await _citiesUnitOfWork.GetAsync(pagination);
        var action = await _citiesUnitOfWork.GetTotalRecordsAsync(pagination);
        if (response.WasSuccess)
        {
            ResponseQuery<City> query = new ResponseQuery<City>
            {
                Data = response.Result!.ToList(),
                total = action.Result.ToString()
            };
            return Ok(query);
        }
        return BadRequest();
    }

    [HttpPost("PostAsyncDto")]
    public  async Task<IActionResult> PostAsync(CityDto model)
    {
        var state = await _statesUnitOfWork.GetAsync(model.StateId);
        
        var response = await _UnitOfWork.AddAsync(new City
        {
            CreationDate = DateTime.Now,
            IsActive = model.IsActive,
            Name = model.Name!,
            State = state.Result!,
            
        });
        if (response.WasSuccess)
        {
            return Ok(model);
        }
        return BadRequest(response.Message);
    }

    [HttpPut("EditAsyncDto")]
    public async Task<IActionResult> EditAsync(CityDto model)
    {
        var city = await _UnitOfWork.GetAsync(model.Id);
        city.Result!.Name = model.Name!;
        city.Result!.IsActive = model.IsActive!;
        var response = await _UnitOfWork.UpdateAsync(city.Result!);
        if (response.WasSuccess)
        {
            return Ok(model);
        }
        return BadRequest(response.Message);
    }

    [HttpGet("totalRecordsPaginated")]
    public virtual async Task<IActionResult> GetTotalRecordsAsync([FromQuery] PaginationDTO pagination)
    {
        var action = await _citiesUnitOfWork.GetTotalRecordsAsync(pagination);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
        return BadRequest();
    }
}