using System.ComponentModel.DataAnnotations;

namespace Mahalo.Shared.Entities;

public class ResourceDisorder
{
    public int Id { get; set; }

    [Display(Name = "Name")]
    [MaxLength(100)]
    [Required]
    public string Name { get; set; } = null!;

    [Display(Name = "CreationDate")]
    [Required]
    public DateTime CreationDate { get; set; }

    [Display(Name = "IsActive")]
    [Required]
    public bool IsActive { get; set; }

    public Disorder? Disorder { get; set; }
    public Resource? Resource { get; set; }
}