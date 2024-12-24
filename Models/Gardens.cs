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
    
    //Navigation properties 
    [ForeignKey("Gardener")]
    public int? Id { get; set; }
    
    public Gardener? Gardener { get; set; }
    
    public ICollection<Plots> Plots { get; set; }
    
    
}