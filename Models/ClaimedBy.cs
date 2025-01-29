using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace BrennansWebsite.Models;
[PrimaryKey(nameof(PlotsId), nameof(Id))]
public class ClaimedBy
{
    public int PlotsId { get; set; }
    
    public int Id { get; set; }
    

    // Navigation properties
    [ForeignKey(nameof(Id))]
    public Gardener Gardener { get; set; }
    [ForeignKey(nameof(PlotsId))]
    public Plots Plots { get; set; }
}