using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahalo.Shared.Entities
{
    public class NotificationSecheduling
    {
        public int Id { get; set; }

        [Display(Name = "SchedulingDays")]
        [MaxLength(100)]
        [Required]
        public DateTime SchedulingDays { get; set; }

        [Display(Name = "IsActive")]
        [Required]
        public bool IsActive { get; set; }

        [Display(Name = "NotificationSecheduling")]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; } = null!;

        public Collection<NotificationSchedulingResource>? NotificationSchedulingResources { get; set; }
    }
}
