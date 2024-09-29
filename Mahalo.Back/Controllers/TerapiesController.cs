using Mahalo.Back.UnitsOfWork.Implementation;
using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Mahalo.Back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TerapiesController : GenericController<Terapy>
{
    private readonly ITerapiesUnitOfWork _unitOfWork;
    private ITerapiesUnitOfWork _TerapiesUnitOfWork;

    public TerapiesController(IGenericUnitOfWork<Terapy> unitOfWork, ITerapiesUnitOfWork terapiesUnitOfWork) : base(unitOfWork)
    {
        _TerapiesUnitOfWork = terapiesUnitOfWork;
    }

    [HttpGet("paginated")]
    public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
    {
        var response = await _TerapiesUnitOfWork.GetAsync(pagination);

        var action = await _TerapiesUnitOfWork.GetTotalRecordsAsync(pagination);
        if (response.WasSuccess)
        {
            ResponseQuery<Terapy> query = new ResponseQuery<Terapy>
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
        var action = await _TerapiesUnitOfWork.GetTotalRecordsAsync(pagination);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
        return BadRequest();
    }
}