using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrennansWebsite.Models;

public class Gardens
{
    [Key]
    public int GardenId { get; set; }
    [MaxLength(40)]
    public string GardenName { get; set; }
    
    public string City { get; set; }
    
    public string Address { get; set; }
    
    //fk to gardens
    public int? LeaderId { get; set; }
    
    //Navigation properties 
    [ForeignKey(nameof(LeaderId))]
    public Gardener? Leader { get; set; }
    
    public ICollection<Plots> Plots { get; set; }
    
    
}