using System.ComponentModel.DataAnnotations;
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
    [MaxLength(50)]
    [Required]
    public string Username { get; set; } = "";
    //pasword
    [Column("password")]
    [MaxLength(100)]
    [Required]
    public string Password { get; set; } = "";
    
    [Required] 
    public string role { get; set; } = "user";
    //nav 
    public Gardener Gardener { get; set; }
}