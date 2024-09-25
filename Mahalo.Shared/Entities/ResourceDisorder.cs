using System.ComponentModel.DataAnnotations;

namespace Mahalo.Shared.Entities;

public class ResourceDisorder
{
    [Display(Name = "CreationDate")]
    [Required]
    public DateTime CreationDate { get; set; }

    public int Id { get; set; }

    [Display(Name = "ResourceDisorder")]
    [MaxLength(100)]
    [Required]
    public string Name { get; set; } = null!;

    [Display(Name = "IsActive")]
    [Required]
    public bool IsActive { get; set; }

    public Disorder? Disorder { get; set; }
    public Resource? Resource { get; set; }
}