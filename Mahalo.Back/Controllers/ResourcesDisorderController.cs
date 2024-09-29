using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mahalo.Back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResourcesDisorderController : GenericController<ResourceDisorder>
{
    private readonly IResourcesDisorderUnitOfWork _resourcesDisorderUnitOfWork;

    public ResourcesDisorderController(IGenericUnitOfWork<ResourceDisorder> unitOfWork, IResourcesDisorderUnitOfWork resourcesDisorderUnitOfWork) : base(unitOfWork)
    {
        _resourcesDisorderUnitOfWork = resourcesDisorderUnitOfWork;
    }

    [HttpPost("paginated")]
    public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
    {
        var response = await _resourcesDisorderUnitOfWork.GetAsync(pagination);
        if (response.WasSuccess)
        {
            return Ok(response.Result);
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