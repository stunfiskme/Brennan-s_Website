﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrennansWebsite.Models;

[Table("userAccount")]
public class UserAccount
{
    //PK
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int userId { get; set; }
    //username
    [Column("username")]
    [MaxLength(20)]
    [Required]
    public string Username { get; set; } = "";
    //salt 
    [Column("salt")]
    [MaxLength(16)] // Salt is 16 bytes long
    [Required]
    public byte[] salt { get; set; }
    //password
    [Column("password")]
    [MaxLength(44)]
    [Required]
    public string Password { get; set; } = "";
    
    [Required] 
    public string role { get; set; } = "user";
    //nav 
    public Gardener Gardener { get; set; }
}