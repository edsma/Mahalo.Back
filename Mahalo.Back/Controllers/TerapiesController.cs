using Mahalo.Back.UnitsOfWork.Implementation;
using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.DTOs;
using Mahalo.Shared.Entities;
using Mahalo.Shared.Enums;
using Mahalo.Shared.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Mahalo.Back.Controllers;

[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
public class TerapiesController : GenericController<Terapy>
{
    private readonly ITerapiesUnitOfWork _unitOfWork;
    private ITerapiesUnitOfWork _TerapiesUnitOfWork;
    private IUsersUnitOfWork _userUnitOfWork;
    private const string emailConst = "email";  

    public TerapiesController(IGenericUnitOfWork<Terapy> unitOfWork, 
        ITerapiesUnitOfWork terapiesUnitOfWork,
        IUsersUnitOfWork userUnitOfWork) : base(unitOfWork)
    {
        _TerapiesUnitOfWork = terapiesUnitOfWork;
        _userUnitOfWork = userUnitOfWork;
    }

    [HttpGet("paginated")]
    public override async Task<IActionResult> GetAsync(PaginationDTO pagination)
    {
        ActionResponse<IEnumerable<Terapy>> response;

        ActionResponse<int> action;
        var user = await _userUnitOfWork.GetUserAsync(User.Identity!.Name!);
        if (user.UserType.Equals(UserType.User))
        {
            response  = await _TerapiesUnitOfWork.GetByUserAsync(pagination, user);
            action = await _TerapiesUnitOfWork.GetTotalRecordsAsync(pagination);
            pagination.UserId = user.Id;
        }
        else
        {
            response = await _TerapiesUnitOfWork.GetAsync(pagination);
            action = await _TerapiesUnitOfWork.GetTotalRecordsAsync(pagination);

        }



        if (response.WasSuccess)
        {
            List<TerapiesDto> result = new List<TerapiesDto>();
            foreach (var terapy in response.Result!)
            {
                result.Add(new TerapiesDto
                {
                    CityId = terapy.City.Id,
                    CityName = terapy.City.Name,    
                    PsychologistName = terapy.Psychologist.Name,
                    PsychologistId = terapy.Psychologist.Id,   
                    Name = terapy.Name,
                    PsychologistAddress = terapy.Psychologist.Address,
                    HourTerapy = terapy.HourTerapy.Date,
                    Id = terapy.Id,
                    IsActive = terapy.IsActive,
                });
            }
            ResponseQuery<TerapiesDto> query = new ResponseQuery<TerapiesDto>
            {
                Data = result,
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