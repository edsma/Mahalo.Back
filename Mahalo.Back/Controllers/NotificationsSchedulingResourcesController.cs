using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mahalo.Back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsSchedulingResourcesController : GenericController<NotificationSchedulingResource>
{
    public NotificationsSchedulingResourcesController(IGenericUnitOfWork<NotificationSchedulingResource> unitOfWork) : base(unitOfWork)
    {
    }
}