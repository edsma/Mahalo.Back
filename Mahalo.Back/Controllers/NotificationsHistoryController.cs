using Mahalo.Back.UnitsOfWork.Interfaces;
using Mahalo.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Mahalo.Back.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsHistoryController : GenericController<NotificationHistory>
{
    public NotificationsHistoryController(IGenericUnitOfWork<NotificationHistory> unitOfWork) : base(unitOfWork)
    {
    }
}