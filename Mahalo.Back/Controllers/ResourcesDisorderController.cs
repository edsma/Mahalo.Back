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
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
public class ResourcesDisorderController : GenericController<ResourceDisorder>
{
    private readonly IResourcesDisorderUnitOfWork _resourcesDisorderUnitOfWork;

    public ResourcesDisorderController(IGenericUnitOfWork<ResourceDisorder> unitOfWork, IResourcesDisorderUnitOfWork resourcesDisorderUnitOfWork) : base(unitOfWork)
    {
        _resourcesDisorderUnitOfWork = resourcesDisorderUnitOfWork;
    }

    [HttpGet("paginated")]
    public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
    {
        var response = await _resourcesDisorderUnitOfWork.GetAsync(pagination);

        var action = await _resourcesDisorderUnitOfWork.GetTotalRecordsAsync(pagination);
        if (response.WasSuccess)
        {
            ResponseQuery<ResourceDisorder> query = new ResponseQuery<ResourceDisorder>
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
        var action = await _resourcesDisorderUnitOfWork.GetTotalRecordsAsync(pagination);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
        return BadRequest();
    }
}