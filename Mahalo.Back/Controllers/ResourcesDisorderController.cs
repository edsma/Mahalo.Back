using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mahalo.Back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResourcesDisorderController : GenericController<ResourceDisorder>
{
    public ResourcesDisorderController(IGenericUnitOfWork<ResourceDisorder> unitOfWork) : base(unitOfWork)
    {
    }
}