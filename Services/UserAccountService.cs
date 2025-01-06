using BrennansWebsite.Data;
using BrennansWebsite.Models;
using Microsoft.EntityFrameworkCore;
namespace BrennansWebsite.Services;

public class UserAccountService
{
    private readonly ApplicationDbContext _context;

    public UserAccountService(ApplicationDbContext context)
    {
        _context = context;
    }
//get all
    public async Task<List<UserAccount>> GetAllAsync()
    {
        return await _context.UserAccount.ToListAsync();
    }
    // get one by id
    public async Task<UserAccount> GetByIdAsync(int userId)
    {
        var UserAccount = await _context.UserAccount.FindAsync(userId);
        if (UserAccount == null)
        {
            throw new Exception("user not found");
        }

        return UserAccount;
    }
    // update role
    public async Task UpdateAsync(UserAccount UserAccount)
    {
        _context.UserAccount.Update(UserAccount);
        await _context.SaveChangesAsync();
    }
}