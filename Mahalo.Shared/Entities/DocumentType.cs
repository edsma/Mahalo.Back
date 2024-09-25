using System.ComponentModel.DataAnnotations;

namespace Mahalo.Shared.Entities;

public class DocumentType
{
    public int Id { get; set; }

    [Display(Name = "DocumentType")]
    [MaxLength(100, ErrorMessageResourceName = "MaxLength")]
    [Required]
    public string Name { get; set; } = null!;

    [Display(Name = "IsActive")]
    [Required]
    public bool IsActive { get; set; }



}