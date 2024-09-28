using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mahalo.Back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatesController : GenericController<State>
{
    public StatesController(IGenericUnitOfWork<State> unitOfWork) : base(unitOfWork)
    {
    }
}