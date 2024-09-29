using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Mahalo.Shared.Entities;

public class NotificationScheduling
{
    public int Id { get; set; }

    [Display(Name = "NotificationSecheduling")]
    [MaxLength(100)]
    [Required]
    public string Name { get; set; } = null!;

    [Display(Name = "SchedulingDays")]
    [MaxLength(100)]
    [Required]
    public DateTime SchedulingDays { get; set; }

    [Display(Name = "IsActive")]
    [Required]
    public bool IsActive { get; set; }

    public Collection<NotificationSchedulingResource>? NotificationsSchedulingResources { get; set; }
}