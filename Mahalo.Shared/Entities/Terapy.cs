using System.ComponentModel.DataAnnotations;

namespace Mahalo.Shared.Entities;

public  class Terapy
{
    public int id { get; set; }

    [Display(Name = "HourTerapy")]
    [Required]
    public DateTime HourTerapy { get; set; }

    [Display(Name = "IsActive")]
    [Required]
    public bool IsActive { get; set; }
    public City City { get; set; } = null!;
    public Psychologist Psychologist { get; set; } = null!;
}