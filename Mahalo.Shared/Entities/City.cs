using System.ComponentModel.DataAnnotations;

namespace Mahalo.Shared.Entities;

public class City
{
    public int Id { get; set; }

   
    [Display(Name = "City")]
    [MaxLength(100, ErrorMessageResourceName = "MaxLength")]
    [Required]
    public string Name { get; set; } = null!;

    [Display(Name = "IsActive")]
    [Required]
    public bool IsActive { get; set; }

    [Display(Name = "CreationDate")]
    [Required]
    public DateTime CreationDate { get; set; }

    public ICollection<User>? Users { get; set; }

    public ICollection<Terapy> Terapies { get; set; } = null!;
    public State State { get; set; } = null!;
}