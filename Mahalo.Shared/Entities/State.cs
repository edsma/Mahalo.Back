using System.ComponentModel.DataAnnotations;

namespace Mahalo.Shared.Entities;

public class State
{
    public int Id { get; set; }


    public Country Country { get; set; } = null!;

    [Display(Name = "State")]
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