using BrennansWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace BrennansWebsite.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

        public DbSet<Gardener> Gardeners { get; set; }
        public DbSet<Gardens> Gardens { get; set; }
        public DbSet<Plots> Plots { get; set; }
        public DbSet<ClaimedBy> ClaimedBys { get; set; }
        public DbSet<BannedCrops> BannedCrops { get; set; }
        public DbSet<CropsGrowing> CropsGrowing { get; set; }
     }
    