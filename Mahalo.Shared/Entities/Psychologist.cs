using System.ComponentModel.DataAnnotations;

namespace Mahalo.Shared.Entities;

public class Psychologist
{
    public int Id { get; set; }


    [Display(Name = "Psychologist")]
    [MaxLength(100, ErrorMessageResourceName = "MaxLength")]
    [Required]
    public string Name { get; set; } = null!;

    [Display(Name = "Address")]
    [MaxLength(200, ErrorMessageResourceName = "MaxLength")]
    [Required]

    public string Address { get; set; } = null!;

    [Display(Name = "XCoordinate")]
    [Required]
    public double XCoordinate { get; set; } = 0;

    [Display(Name = "YCoordinate")]
    [Required]
    public double YCoordinate { get; set; } = 0;

    [Display(Name = "OfficeStart")]
    [Required]
    public DateTime OfficeStart { get; set; }
    
    [Display(Name = "OfficeEnd")]
    [Required]
    public DateTime OfficeEnd { get; set; }

    [Display(Name = "IsActive")]
    [Required]
    public bool IsActive { get; set; }

    [Display(Name = "CreationDate")]
    [Required]
    public DateTime CreationDate { get; set; }

    public double TerapyPrice { get; set; }

    public ICollection<City>? Cities { get; set; }

    public ICollection<Terapy> Terapies { get; set; } = null!;
}