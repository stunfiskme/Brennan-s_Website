using BrennansWebsite.Data;
using BrennansWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace BrennansWebsite.Services;

public class GardenersService
{
    private readonly ApplicationDbContext _context;

    public GardenersService(ApplicationDbContext context)
    {
        _context = context;
    }

//get all
    public async Task<List<Gardener>> GetAllAsync()
    {
        return await _context.Gardeners.ToListAsync();
    }

    // get by id
    public async Task<Gardener> GetByIdAsync(int id)
    {
        var Gardener = await _context.Gardeners.FindAsync(id);
        if (Gardener == null)
        {
            throw new Exception("Garderner not found");
        }

        return Gardener;
    }

// update
    public async Task UpdateAsync(Gardener Gardener)
    {
        _context.Gardeners.Update(Gardener);
        await _context.SaveChangesAsync();
    }

//delete
    public async Task DeleteAsync(int id)
    {
        var Gardener = await _context.Gardeners.FindAsync(id);
        if (Gardener != null)
        {
            _context.Gardeners.Remove(Gardener);
            await _context.SaveChangesAsync();
        }
    }
}