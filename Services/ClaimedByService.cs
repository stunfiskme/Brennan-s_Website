using BrennansWebsite.Data;
using BrennansWebsite.Models;
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
        var ClaimedBy = await _context.ClaimedBys.ToListAsync();
        ClaimedBy = ClaimedBy.Where(ClaimedBy => ClaimedBy.Id == Id).ToList();
        return ClaimedBy;
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
        var ClaimedBy = await _context.ClaimedBys.FindAsync();
        if (ClaimedBy != null)
        {
            _context.ClaimedBys.Remove(ClaimedBy);
            await _context.SaveChangesAsync();
        }
    }
}