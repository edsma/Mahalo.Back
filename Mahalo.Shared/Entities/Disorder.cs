using System.ComponentModel.DataAnnotations;

namespace Mahalo.Shared.Entities;

public class Disorder
{
        public int Id { get; set; }

    [Display(Name = "Disorder")]
    [MaxLength(100)]
    [Required]
    public string Name { get; set; } = null!;

    [Display(Name = "IsActive")]
    [Required]
    public bool IsActive { get; set; }

    [Display(Name = "CreationDate")]
    [Required]
    public DateTime CreationDate { get; set; }

    public ICollection<ResourceDisorder>? ResourcesDisorder { get; set; }
}