using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public int ID { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [MaxLength(100)]
    public string Email { get; set; }

    [MaxLength(15)]
    public string Phone { get; set; }

    public DateTime RegistrationDate { get; set; }

    public ICollection<Ad> Ads { get; set; }
}
