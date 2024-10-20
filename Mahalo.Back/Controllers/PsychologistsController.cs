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
public class PsychologistsController : GenericController<Psychologist>
{
    private readonly IPsychologistsUnitOfWork _psychologistsUnitOfWork;
    private readonly ICitiesUnitOfWork _citiesUnitOfWork;
    private readonly IGenericUnitOfWork<Psychologist> _unitOfWork;

    public PsychologistsController(IGenericUnitOfWork<Psychologist> unitOfWork, ICitiesUnitOfWork citiesUnitOfWork,  IPsychologistsUnitOfWork psychologistsUnitOfWork) : base(unitOfWork)
    {
        _psychologistsUnitOfWork = psychologistsUnitOfWork;
        _unitOfWork = unitOfWork;
        _citiesUnitOfWork = citiesUnitOfWork;
    }

    [HttpGet("paginated")]
    public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
    {
        var response = await _psychologistsUnitOfWork.GetAsync(pagination);

        var action = await _psychologistsUnitOfWork.GetTotalRecordsAsync(pagination);
        if (response.WasSuccess)
        {
            ResponseQuery<Psychologist> query = new ResponseQuery<Psychologist>
            {
                Data = response.Result!.ToList(),
                total = action.Result.ToString()
            };
            return Ok(query);
        }
        return BadRequest();
    }

    [HttpPost("PostAsyncDto")]
    public async Task<IActionResult> PostAsync(PsychologistsDTO model)
    {
        var city = await _citiesUnitOfWork.GetAsync(1);
        var response = await _unitOfWork.AddAsync(new Psychologist
        {
            CreationDate = DateTime.Now,
            IsActive = model.IsActive,
            Name = model.Name!,
            Address = model.Address,
            OfficeEnd = model.OfficeEnd,
            OfficeStart = model.OfficeStart,
            TerapyPrice = model.TerapyPrice,
            XCoordinate = model.XCoordinate,
            YCoordinate = model.YCoordinate,
            City = city.Result!
            
        });
        if (response.WasSuccess)
        {
            return Ok(model);
        }
        return BadRequest(response.Message);
    }

    [HttpPut("EditAsyncDto")]
    public async Task<IActionResult> EditAsync(PsychologistsDTO model)
    {
        var city = await _unitOfWork.GetAsync(1);
        city.Result!.Name = model.Name!;
        city.Result!.IsActive = model.IsActive!;
        var response = await _unitOfWork.UpdateAsync(city.Result!);
        if (response.WasSuccess)
        {
            return Ok(model);
        }
        return BadRequest(response.Message);
    }

    [HttpGet("totalRecordsPaginated")]
    public virtual async Task<IActionResult> GetTotalRecordsAsync([FromQuery] PaginationDTO pagination)
    {
        var action = await _psychologistsUnitOfWork.GetTotalRecordsAsync(pagination);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
        return BadRequest();
    }
}