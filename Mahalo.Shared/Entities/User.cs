using Mahalo.Shared.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Mahalo.Shared.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    public string? NumberDocument { get; set; } = null!;

    [Display(Name = "Image")]
    public string? Photo { get; set; }

    [Display(Name = "UserType")]
    public UserType UserType { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    [Display(Name = "CreationDate")]
    [Required]
    public DateTime CreationDate { get; set; }

    [Display(Name = "IsActive")]
    [Required]
    public bool IsActive { get; set; }

    public DocumentType? DocumentType { get; set; }
    public City? City { get; set; }

    public ICollection<Terapy>? Terapies { get; set; }

    public ICollection<Disorder>? Disorders { get; set; }

    public ICollection<Resource>? Resources { get; set; }

    public ICollection<NotificationScheduling>? NotificationsScheduling { get; set; }
}