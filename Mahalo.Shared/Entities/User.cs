using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Mahalo.Shared.Entities;

public class User
{
    public int Id { get; set; }

    [Display(Name = "Name")]
    [MaxLength(100, ErrorMessageResourceName = "MaxLength")]
    [Required]
    public string Name { get; set; } = null!;

    [Display(Name = "Email")]
    [MaxLength(100, ErrorMessageResourceName = "MaxLength")]
    [Required]
    public string Email { get; set; } = null!;

    [Display(Name = "Password")]
    [MaxLength(100, ErrorMessageResourceName = "MaxLength")]
    [Required]
    public string Password { get; set; } = null!;

    [Display(Name = "IsActive")]
    [Required]
    public bool IsActive { get; set; }

    [Display(Name = "CreationDate")]
    [Required]
    public DateTime CreationDate { get; set; }

    public DocumentType DocumentType { get; set; } = null!;
    public City City { get; set; } = null!;

    public ICollection<Terapy> Terapies { get; set; } = null!;

    public ICollection<Disorder> Disorders { get; set; } = null!;

    public ICollection<Resource> Resources { get; set; } = null!;

    public ICollection<NotificationScheduling> NotificationsScheduling { get; set; } = null!;

}