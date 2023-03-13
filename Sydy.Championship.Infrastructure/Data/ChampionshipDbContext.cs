using Microsoft.EntityFrameworkCore;
using Sydy.Championship.CoreBusiness.Entities;
using Sydy.Championship.Infrastructure.Configuration;

namespace Sydy.Championship.Infrastructure.Data
{
    public class ChampionshipDbContext : DbContext
    {
        public ChampionshipDbContext(DbContextOptions<ChampionshipDbContext> options) : base(options) { }

        public DbSet<TeamModel> Teams { get; set; }
        public DbSet<ChampionshipModel> Championships { get; set; }
        public DbSet<MatchModel> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new ChampionshipConfiguration());
            modelBuilder.ApplyConfiguration(new MatchConfiguration());
            modelBuilder.ApplyConfiguration(new VwMatchResultsConfiguration());
        }
    }
}
