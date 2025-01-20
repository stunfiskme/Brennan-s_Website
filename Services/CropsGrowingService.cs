using BrennansWebsite.Data;
using BrennansWebsite.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace BrennansWebsite.Services;

public class CropsGrowingService
{
    private readonly ApplicationDbContext _context;

    public CropsGrowingService(ApplicationDbContext context)
    {
        _context = context;
    }

//get all
    public async Task<List<CropsGrowing>> GetAllAsync()
    {
        return await _context.CropsGrowing.ToListAsync();
    }
// get all the plots in a garden
    
    public async Task<List<CropsGrowing>> GetTheOnesInThisPlotAsync(int PlotsId)
    {
        var CropsGrowing = await _context.CropsGrowing.
            Where(CropsGrowing => CropsGrowing.PlotsId == PlotsId).ToListAsync();
        return CropsGrowing;
    }
    // get one by id
    public async Task<CropsGrowing> GetByIdAsync(int PlotsId, string cropName)
    {
        var CropsGrowing = await _context.CropsGrowing.FindAsync(PlotsId, cropName);
        if (CropsGrowing == null)
        {
            throw new Exception("crops not found");
        }

        return CropsGrowing;
    }

// update
    public async Task UpdateAsync(int PlotsId, string cropName, string oldName)
    {
        string query = "UPDATE CropsGrowing SET cropName = @NewCropName WHERE PlotsId = @PlotsId AND cropName = @OldCropName;";
        var parameters = new[]
        {
            new SqlParameter("@PlotsId", PlotsId),
            new SqlParameter("@NewCropName", cropName), 
            new SqlParameter("@OldCropName", oldName)   
        };
        await _context.Database.ExecuteSqlRawAsync(query, parameters);
    }


//delete a crop
    public async Task DeleteAsync(int PlotsId, string cropName )
    {
        var CropsGrowing = await _context.CropsGrowing.FindAsync(PlotsId, cropName);
        if (CropsGrowing != null)
        {
            _context.CropsGrowing.Remove(CropsGrowing);
            await _context.SaveChangesAsync();
        }
    }
}