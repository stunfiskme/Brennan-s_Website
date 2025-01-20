using BrennansWebsite.Data;
using BrennansWebsite.Models;
using Microsoft.EntityFrameworkCore;
namespace BrennansWebsite.Services;

public class GardensService
{
    private readonly ApplicationDbContext _context;

    public GardensService(ApplicationDbContext context)
    {
        _context = context;
    }

//get all
    public async Task<List<Gardens>> GetAllAsync()
    {
        return await _context.Gardens.ToListAsync();
    }

    // get one by id
    public async Task<Gardens> GetByIdAsync(int id)
    {
        var garden = await _context.Gardens.FindAsync(id);
        if (garden == null)
        {
            throw new Exception("club not found");
        }

        return garden;
    }
    //get leaders and gardens
    public async Task<List<Gardens>> GeAllLeadersAndGardens()
    {
        return await _context.Gardens.Include(g => g.Leader).ToListAsync();
    }
// update
    public async Task UpdateGardenAsync(Gardens garden)
    {
        _context.Gardens.Update(garden);
        await _context.SaveChangesAsync();
    }

//delete
    public async Task DeleteGardenAsync(int id)
    {
        var gardens = await _context.Gardens.FindAsync(id);
        if (gardens != null)
        {
            _context.Gardens.Remove(gardens);
            await _context.SaveChangesAsync();
        }
    }
}