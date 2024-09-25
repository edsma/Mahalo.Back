using Mahalo.Back.Data;
using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mahalo.Back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentTypesController : GenericController<DocumentType>
{
    public DocumentTypesController(IGenericUnitOfWork<DocumentType> unitOfWork) : base(unitOfWork)
    {
            
    }
}
