using BrennansWebsite.Data;
using BrennansWebsite.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace BrennansWebsite.Services;

public class ClaimedByService
{
    private readonly ApplicationDbContext _context;

    public ClaimedByService(ApplicationDbContext context)
    {
        _context = context;
    }

//get all
    public async Task<List<ClaimedBy>> GetAllAsync()
    {
        return await _context.ClaimedBys.ToListAsync();
    }
// get all the claim for a gardener
    public async Task<List<ClaimedBy>> GetTheOnesForThisGardenerAsync(int Id)
    {
        var ClaimedBy = await _context.ClaimedBys.
            Where(ClaimedBy => ClaimedBy.Id == Id).ToListAsync();
        return ClaimedBy;
    }
    //get the claims for this gardeners along with the plot and gardener name/s 
    public async Task<List<ClaimedBy>> GetAllInfo(int gardenerId)
    {
        return await _context.ClaimedBys.Where(ClaimedBy => ClaimedBy.Id == gardenerId).
            Include(b => b.Plots).ToListAsync();
    }
    // get one by id
    public async Task<ClaimedBy> GetByIdAsync(int PlotsId, int Id)
    {
        var CropsGrowing = await _context.ClaimedBys.FindAsync(PlotsId, Id);
        if (CropsGrowing == null)
        {
            throw new Exception("crops not found");
        }

        return CropsGrowing;
    }
    
//delete a claim
    public async Task DeleteAsync(int PlotsId, int Id)
    {
        var ClaimedBy = await _context.ClaimedBys.FindAsync(PlotsId ,Id);
        if (ClaimedBy != null)
        {
            _context.ClaimedBys.Remove(ClaimedBy);
            await _context.SaveChangesAsync();
        }
    }
    //get all the claimed plots in the garden
    public async Task<List<ClaimedBy>> GetTheOnesForThisGardenAsync(int gardenId)
    {
        string query = "SELECT * FROM ClaimedBys JOIN Plots ON Plots.PlotId = ClaimedBys.PlotsId WHERE Plots.GardenId = @gardenId";
        var parameters = new[]
        {
            new SqlParameter("@gardenId", gardenId)
        };
        var result = await _context.ClaimedBys
            .FromSqlRaw(query, parameters).ToListAsync();
        return result;
    }
}