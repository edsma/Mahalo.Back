using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mahalo.Back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DisordersController : GenericController<Disorder> { 

    public DisordersController(IGenericUnitOfWork<Disorder> unitOfWork) : base(unitOfWork)
    {
    }
}