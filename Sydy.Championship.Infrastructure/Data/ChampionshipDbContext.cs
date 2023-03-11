using Microsoft.EntityFrameworkCore;
using Sydy.Championship.CoreBusiness.Entities;
using Sydy.Championship.Infrastructure.Configuration;

namespace Sydy.Championship.Infrastructure.Data
{
    public class ChampionshipDbContext : DbContext
    {
        public ChampionshipDbContext(DbContextOptions<ChampionshipDbContext> options) : base(options) { }

        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
        }
    }
}
