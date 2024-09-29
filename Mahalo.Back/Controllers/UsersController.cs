using Mahalo.Back.UnitsOfWork.Implementation;
using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Mahalo.Back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : GenericController<User>
{
    private IUsersUnitOfWork _usersUnitOfWork;

    public UsersController(IGenericUnitOfWork<User> unitOfWork, IUsersUnitOfWork usersUnitOfWork) : base(unitOfWork)
    {
        _usersUnitOfWork = usersUnitOfWork;
    }

    [HttpGet("paginated")]
    public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
    {
        var response = await _usersUnitOfWork.GetAsync(pagination);
        var action = await _usersUnitOfWork.GetTotalRecordsAsync(pagination);
        if (response.WasSuccess)
        {
            ResponseQuery<User> query = new ResponseQuery<User>
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
        var action = await _usersUnitOfWork.GetTotalRecordsAsync(pagination);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
        return BadRequest();
    }
}