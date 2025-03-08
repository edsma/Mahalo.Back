using System.ComponentModel.DataAnnotations;

namespace Mahalo.Shared.Entities;

public class Resource
{
    public int Id { get; set; }

    [Display(Name = "Name")]
    [MaxLength(100)]
    [Required]
    public string Name { get; set; } = null!;

    [Display(Name = "Name")]
    [MaxLength(100)]
    [Required]
    public string Description { get; set; } = null!;

    [Display(Name = "Location")]
    [MaxLength(500)]
    [Required]
    public string Location { get; set; } = null!;

    [Display(Name = "CreationDate")]
    [Required]
    public DateTime CreationDate { get; set; }

    [Display(Name = "ModifiedDate")]
    public DateTime ModifiedDate { get; set; }

    [Display(Name = "Status")]
    [MaxLength(100)]
    [Required]
    public string Status { get; set; } = null!;

    [Display(Name = "IsActive")]
    [Required]
    public bool IsActive { get; set; }

    public int ResourceDisorderId { get; set; }
    public string? UserId { get; set; }

    //public ICollection<ResourceDisorder>? ResourcesDisorder { get; set; }
    public ICollection<NotificationHistory>? NotificationsHistory { get; set; }
    public ICollection<NotificationSchedulingResource>? NotificationsSchedulingResources { get; set; }



}
