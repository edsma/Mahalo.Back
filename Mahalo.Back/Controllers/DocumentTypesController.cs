using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mahalo.Back.Controllers;

[ApiController]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
public class DocumentTypesController : GenericController<DocumentType>
{
    private readonly IDocumentTypesUnitOfWork _documentTypesUnitOfWork;

    public DocumentTypesController(IGenericUnitOfWork<DocumentType> unitOfWork, IDocumentTypesUnitOfWork documentTypesUnitOfWork) : base(unitOfWork)
    {
        _documentTypesUnitOfWork = documentTypesUnitOfWork;
    }

    [HttpGet("paginated")]
    public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
    {
        var response = await _documentTypesUnitOfWork.GetAsync(pagination);

        var action = await _documentTypesUnitOfWork.GetTotalRecordsAsync(pagination);
        if (response.WasSuccess)
        {
            ResponseQuery<DocumentType> query = new ResponseQuery<DocumentType>
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
        var action = await _documentTypesUnitOfWork.GetTotalRecordsAsync(pagination);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
        return BadRequest();
    }
}