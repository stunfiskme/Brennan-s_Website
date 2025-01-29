using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrennansWebsite.Models;

public class Plots
{
    [Key]
    public int PlotId { get; set; }
    [MaxLength(20)]
    public string PlotName { get; set; }
    
    public int GardenId { get; set; }
    
    //nav props
    [ForeignKey(nameof(GardenId))]
    public Gardens Gardens { get; set; }
    public ICollection<ClaimedBy> ClaimedBy { get; set; }
}