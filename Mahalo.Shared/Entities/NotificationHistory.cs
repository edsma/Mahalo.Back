using System.ComponentModel.DataAnnotations;

namespace Mahalo.Shared.Entities;

public class NotificationHistory
{
    public int Id { get; set; }


    

    [Display(Name = "CreationDate")]
    [Required]
    public DateTime CreationDate { get; set; }

    [Display(Name = "IsActive")]
    [Required]
    public bool IsActive { get; set; }
    public Resource? Resource { get; set; }

    public ICollection<User> Users { get; set; } = null!;

}
