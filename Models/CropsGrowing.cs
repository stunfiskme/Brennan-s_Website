using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BrennansWebsite.Models;
[PrimaryKey(nameof(PlotsId), nameof(cropName))]
public class CropsGrowing
{
    public int PlotsId { get; set; }
    [MaxLength(50)]
    public string cropName { get; set; }
    
    public bool PublicStatus { get; set; }
    
    // Navigation property
    [ForeignKey(nameof(PlotsId))]
    public Plots Plots { get; set; }
}