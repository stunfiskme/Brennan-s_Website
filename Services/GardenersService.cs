using BrennansWebsite.Data;
using BrennansWebsite.Models;
using Microsoft.Data.SqlClient;
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
    //get all info in gardeners and userAccount
    public async Task<List<Gardener>> GetAllInfo()
    {
        return await _context.Gardeners.Include(u => u.UserAccount).ToListAsync();
    } 

    // get by id
    public async Task<Gardener> GetByIdAsync(int id)
    {
        var Gardener = await _context.Gardeners.FirstOrDefaultAsync(g => g.GardenerId == id);
        if (Gardener == null)
        {
            throw new Exception("Garderner not found");
        }

        return Gardener;
    }
    
//
    public async Task<int> GetByUserIdAsync(int userID)
    {
        string query = "SELECT id FROM Gardeners WHERE userId = @UserId";
        var parameters = new[]
        {
            new SqlParameter("@UserId", userID)
        };
        var result = await _context.Gardeners
            .FromSqlRaw(query, parameters)
            .Select(g => g.GardenerId)  
            .FirstOrDefaultAsync();
        
        return result;
    }
    //get all in this garden
    public async Task<List<Gardener>> getAllGardenersWhoHaveACliamInThisGarden(int gardenId)
    {
        string query = "SELECT Gardeners.Id ,FirstName,LastName,userId FROM((SELECT * FROM ClaimedBys JOIN Plots ON Plots.PlotId = ClaimedBys.PlotsId WHERE Plots.GardenId = @gardenId) As ClaimsInGarden JOIN Gardeners ON ClaimsInGarden.id = Gardeners.Id)";
        var parameters = new[]
        {
            new SqlParameter("@gardenId", gardenId)
        };
        var result = await _context.Gardeners
            .FromSqlRaw(query, parameters).ToListAsync();
        return result;
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