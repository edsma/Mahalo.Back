using System.ComponentModel.DataAnnotations;

namespace Mahalo.Shared.Entities;

public class Resource
{
    public int Id { get; set; }

    [Display(Name = "CreationDate")]
    [Required]
    public DateTime CreationDate { get; set; }

    [Display(Name = "IsActive")]
    [Required]
    public bool IsActive { get; set; }

    [Display(Name = "Location")]
    [MaxLength(100)]
    [Required]
    public string Location { get; set; } = null!;

    [Display(Name = "ModifiedDate")]
    public DateTime ModifiedDate { get; set; }

    [Display(Name = "Resource")]
    [MaxLength(100)]
    [Required]
    public string Name { get; set; } = null!;

    [Display(Name = "State")]
    [MaxLength(100)]
    [Required]
    public string State { get; set; } = null!;

    public ICollection<ResourceDisorder>? ResourceDisorderes { get; set; }
    public ICollection<NotificationHistory>? NotificationHistories { get; set; }
    public ICollection<NotificationSchedulingResource>? NotificationSchedulingResources { get; set; }

    public int TotalResources => ResourceDisorderes == null ? 0 : ResourceDisorderes.Count;


}
