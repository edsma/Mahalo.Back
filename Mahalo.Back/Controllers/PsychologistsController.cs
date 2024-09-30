using Mahalo.Back.UnitsOfWork.Implementation;
using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Mahalo.Back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PsychologistsController : GenericController<Psychologist>
{
    private readonly IPsychologistsUnitOfWork _psychologistsUnitOfWork;

    public PsychologistsController(IGenericUnitOfWork<Psychologist> unitOfWork, IPsychologistsUnitOfWork psychologistsUnitOfWork) : base(unitOfWork)
    {
        _psychologistsUnitOfWork = psychologistsUnitOfWork;
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