using BrennansWebsite.Data;
using BrennansWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace BrennansWebsite.Services;

public class BannedCropsService
{
    private readonly ApplicationDbContext _context;

    public BannedCropsService(ApplicationDbContext context)
    {
        _context = context;
    }

//get all
    public async Task<List<BannedCrops>> GetAllAsync()
    {
        return await _context.BannedCrops.ToListAsync();
    }
// get all the plots in a garden
    
    public async Task<List<BannedCrops>> GetTheOnesInThisGardenAsync(int bannedID)
    {
        var BannedCrops = await _context.BannedCrops.Where
            (BannedCrops => BannedCrops.GardenId == bannedID).ToListAsync();
        return BannedCrops;
    }
    // get one by id
    public async Task<BannedCrops> GetByIdAsync(int bannedID)
    {
        var CropsAllowed = await _context.BannedCrops.FindAsync(bannedID);
        if (CropsAllowed == null)
        {
            throw new Exception("crops not found");
        }

        return CropsAllowed;
    }

// update
    public async Task UpdateAsync(BannedCrops bannedCrops)
    {
        _context.BannedCrops.Update(bannedCrops);
        await _context.SaveChangesAsync();
    }

//delete
    public async Task DeleteAsync(int bannedID)
    {
        var CropsAllowed = await _context.BannedCrops.FindAsync(bannedID);
        if (CropsAllowed != null)
        {
            _context.BannedCrops.Remove(CropsAllowed);
            await _context.SaveChangesAsync();
        }
    }
}
