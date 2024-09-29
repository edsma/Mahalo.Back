using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mahalo.Back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResourcesController : GenericController<Resource>
{
    private readonly IResourcesUnitOfWork _resourcesUnitOfWork;

    public ResourcesController(IGenericUnitOfWork<Resource> unitOfWork, IResourcesUnitOfWork resourcesUnitOfWork) : base(unitOfWork)
    {
        _resourcesUnitOfWork = resourcesUnitOfWork;
    }

    [HttpPost("paginated")]
    public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
    {
        var response = await _resourcesUnitOfWork.GetAsync(pagination);
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest();
    }

    [HttpGet("totalRecordsPaginated")]
    public virtual async Task<IActionResult> GetTotalRecordsAsync([FromQuery] PaginationDTO pagination)
    {
        var action = await _resourcesUnitOfWork.GetTotalRecordsAsync(pagination);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
        return BadRequest();
    }
}