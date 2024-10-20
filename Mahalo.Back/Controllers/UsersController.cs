using Mahalo.Back.UnitsOfWork.Implementation;
using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Enums;
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
            List<UserDTO> responseUsers = new List<UserDTO>();
            foreach (var item in response.Result)
            {
                responseUsers.Add(new UserDTO
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    CreationDate = item.CreationDate,
                    IsActive = item.IsActive,
                    Photo = item.Photo
                });
            }
            ResponseQuery<UserDTO> query = new ResponseQuery<UserDTO>
            {
                Data = responseUsers,
                total = action.Result.ToString()
            };
            return Ok(query);
        }
        return BadRequest();
    }

    [HttpPut("EditAsyncDto")]
    public async Task<IActionResult> EditAsync(UserDTO model)
    {
        var user = await _usersUnitOfWork.GetUserAsync(model.Email);
        user.FirstName = model.FirstName!;
        user.LastName = model.LastName!;
        user.IsActive = model.IsActive;
        user.UserType = (UserType)Convert.ToInt32(user.UserType);
        var response = await _usersUnitOfWork.UpdateUserAsync(user);
        if (response.Succeeded)
        {
            return Ok(model);
        }
        return BadRequest(response.Errors);
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