using System.ComponentModel.DataAnnotations;

namespace Mahalo.Shared.Entities;

public class City
{
    public int Id { get; set; }

    public State State { get; set; } = null!;

    [Display(Name = "City")]
    [MaxLength(100, ErrorMessageResourceName = "MaxLength")]
    [Required]
    public string Name { get; set; }

    [Display(Name = "IsActive")]
    [Required]
    public bool IsActive { get; set; }

    [Display(Name = "CreationDate")]
    [Required]
    public DateTime CreationDate { get; set; }

}