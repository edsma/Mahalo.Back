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
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
public class StatesController : GenericController<State>
{
    private readonly IStatesUnitOfWork _statesUnitOfWork;
    private readonly ICountriesUnitOfWork _countriesUnitOfWork;
    private readonly IGenericUnitOfWork<State> _unitOfWork;

    public StatesController(IGenericUnitOfWork<State> unitOfWork, IStatesUnitOfWork statesUnitOfWork, ICountriesUnitOfWork countriesUnitOfWork) : base(unitOfWork)
    {
        _statesUnitOfWork = statesUnitOfWork;
        _unitOfWork = unitOfWork;
        _countriesUnitOfWork = countriesUnitOfWork; 
    }

    [HttpGet("paginated")]
    public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
    {
        var response = await _statesUnitOfWork.GetAsync(pagination);

        var action = await _statesUnitOfWork.GetTotalRecordsAsync(pagination);
        if (response.WasSuccess)
        {
            List<StateDto> dtoList = new List<StateDto>();
            foreach (var item in response.Result)
            {
                dtoList.Add(new StateDto
                {
                    CreationDate = item.CreationDate,
                    Id = item.Id,
                    IsActive = item.IsActive,
                    Name = item.Name,
                });
            }
            ResponseQuery<StateDto> query = new ResponseQuery<StateDto>
            {
                Data = dtoList,
                total = action.Result.ToString()
            };
            return Ok(query);
        }
        return BadRequest();
    }

    [HttpPost("PostAsyncDto")]
    public async Task<IActionResult> PostAsync(StateDto model)
    {
        var state = await _countriesUnitOfWork.GetAsync(model.CountryId);

        var response = await _unitOfWork.AddAsync(new State
        {
            CreationDate = DateTime.Now,
            IsActive = model.IsActive,
            Name = model.Name!,
            Country = state.Result!,
        });
        if (response.WasSuccess)
        {
            return Ok(model);
        }
        return BadRequest(response.Message);
    }

    [HttpPut("EditAsyncDto")]
    public async Task<IActionResult> EditAsync(StateDto model)
    {
        var state = await _unitOfWork.GetAsync(model.Id);
        state.Result!.Name = model.Name!;
        state.Result!.IsActive = model.IsActive!;
        var response = await _unitOfWork.UpdateAsync(state.Result!);
        if (response.WasSuccess)
        {
            return Ok(model);
        }
        return BadRequest(response.Message);
    }

    [HttpGet("totalRecordsPaginated")]
    public virtual async Task<IActionResult> GetTotalRecordsAsync([FromQuery] PaginationDTO pagination)
    {
        var action = await _statesUnitOfWork.GetTotalRecordsAsync(pagination);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
        return BadRequest();
    }
}