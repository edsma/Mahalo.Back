using System.ComponentModel.DataAnnotations;

namespace Mahalo.Shared.Entities;

public class Terapy
{
    public int Id { get; set; }

    [Display(Name = "HourTerapy")]
    [Required]
    public DateTime HourTerapy { get; set; }

    [Display(Name = "Name")]
    [MaxLength(100, ErrorMessageResourceName = "MaxLength")]
    [Required]
    public string Name { get; set; } = null!;

    [Display(Name = "IsActive")]
    [Required]
    public bool IsActive { get; set; }

    public City? City { get; set; }
    public Psychologist? Psychologist { get; set; }
}