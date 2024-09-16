// Models/User.cs
using System;
using System.ComponentModel.DataAnnotations;

public class User

 
{
    [Key]
    public int UserId { get; set; }

    [Required]
    [StringLength(255)]
    public string Username { get; set; }

    [Required]
    [StringLength(255)]
    public string password { get; set; } // Ensure this matches the column name in your database

    [Required]
    [StringLength(255)]
    public string Email { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
