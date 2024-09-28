using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mahalo.Back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : GenericController<Country>
{
    public UsersController(IGenericUnitOfWork<Country> unitOfWork) : base(unitOfWork)
    {
    }
}