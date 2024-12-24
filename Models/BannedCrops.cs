using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BrennansWebsite.Models;


public class BannedCrops
{
    [Key]
    public int bannedID { get; set; }
    public int GardenId { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string CropName { get; set; }

    // Navigation properties
    [ForeignKey(nameof(GardenId))]
    public Gardens Gardens { get; set; }
}