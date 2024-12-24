using BrennansWebsite.Data;
using BrennansWebsite.Models;
using Microsoft.EntityFrameworkCore;
namespace BrennansWebsite.Services;

public class PlotsServices
{
    private readonly ApplicationDbContext _context;

    public PlotsServices(ApplicationDbContext context)
    {
        _context = context;
    }

//get all
    public async Task<List<Plots>> GetAllAsync()
    {
        return await _context.Plots.ToListAsync();
    }
    // get all the plots in a garden
    
    public async Task<List<Plots>> GetTheOnesInThisGardenAsync(int gardenId )
    {
        var plots = await _context.Plots.ToListAsync();
        plots = plots.Where(Plots => Plots.GardenId == gardenId).ToList();
        return plots;
    }

    // get by id
    public async Task<Plots> GetByIdAsync(int id)
    {
        var Plot = await _context.Plots.FindAsync(id);
        if (Plot == null)
        {
            throw new Exception("Plot not found");
        }

        return Plot;
    }

// update
    public async Task UpdateAsync(Plots Plot)
    {
        _context.Plots.Update(Plot);
        await _context.SaveChangesAsync();
    }

//delete
    public async Task DeleteAsync(int id)
    {
        var Plot = await _context.Plots.FindAsync(id);
        if (Plot != null)
        {
            _context.Plots.Remove(Plot);
            await _context.SaveChangesAsync();
        }
    }
}
