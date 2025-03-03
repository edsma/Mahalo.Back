﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mahalo.Shared.Entities;

public class City
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

    public State State { get; set; } = null!;
    public ICollection<User>? Users { get; set; }

    public ICollection<Terapy>? Terapies { get; set; }
}