using System.ComponentModel.DataAnnotations;

namespace Mahalo.Shared.Entities;

public class NotificationSchedulingResource
{
    public int Id { get; set; }

    [Display(Name = "SchedulingDays")]
    [MaxLength(100)]
    [Required]
    public DateTime SchedulingDays { get; set; }

    [Display(Name = "IsActive")]
    [Required]
    public bool IsActive { get; set; }

    public Resource Resource { get; set; } = null!;

    public NotificationScheduling? NotificationsScheduling { get; set; }
}