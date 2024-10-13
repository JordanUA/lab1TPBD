using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Ad
{
    [Key]
    public int ID { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    public decimal Price { get; set; }

    public int UserID { get; set; }

    [ForeignKey("UserID")]
    public User User { get; set; }
}
