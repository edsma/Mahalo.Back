using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mahalo.Back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsSchedulingController : GenericController<NotificationScheduling>
{
    public NotificationsSchedulingController(IGenericUnitOfWork<NotificationScheduling> unitOfWork) : base(unitOfWork)
    {
    }
}