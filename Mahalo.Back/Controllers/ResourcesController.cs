using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mahalo.Back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResourcesController : GenericController<Resource>
{
    public ResourcesController(IGenericUnitOfWork<Resource> unitOfWork) : base(unitOfWork)
    {
    }
}