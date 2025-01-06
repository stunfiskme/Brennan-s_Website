using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrennansWebsite.Models;

public class Gardener
{
    [Key]
    [Column("id")]
    public int GardenerId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    //fk to users
    [Column("userId")]
    public int userId { get; set;}
   
    
    //nav props
    public ICollection<ClaimedBy> ClaimedBy { get; set; }
    
    [ForeignKey(nameof(userId))]
    public virtual UserAccount UserAccount { get; set; }
    
}