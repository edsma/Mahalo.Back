using System.ComponentModel.DataAnnotations;

namespace Mahalo.Shared.Entities;

public class Country
{
    public int Id { get; set; }

    [Display(Name = "Country")]
    [MaxLength(100, ErrorMessageResourceName = "MaxLength")]
    [Required]
    public string Name { get; set; } = null!;

    [Display(Name = "IsActive")]
    [Required]
    public bool IsActive { get; set; }

    [Display(Name = "CreationDate")]
    [Required]
    public DateTime CreationDate { get; set; }
}