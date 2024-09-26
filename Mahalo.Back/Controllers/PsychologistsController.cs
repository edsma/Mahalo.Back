using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mahalo.Back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PsychologistsController : GenericController<Psychologist>
{
    public PsychologistsController(IGenericUnitOfWork<Psychologist> unitOfWork) : base(unitOfWork)
    {
    }
}