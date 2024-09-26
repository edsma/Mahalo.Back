using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mahalo.Back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TerapiesController : GenericController<Country>
{
    public TerapiesController(IGenericUnitOfWork<Country> unitOfWork) : base(unitOfWork)
    {
    }
}