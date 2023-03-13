using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sydy.Championship.CoreBusiness.Entities;

namespace Sydy.Championship.Infrastructure.Configuration
{
    public class ChampionshipConfiguration : IEntityTypeConfiguration<ChampionshipModel>
    {
        public void Configure(EntityTypeBuilder<ChampionshipModel> builder)
        {
            builder.ToTable("Championship");
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Year).IsRequired();
            builder.Property(c => c.Champion).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Vice).IsRequired().HasMaxLength(50);
            builder.Property(c => c.ThirdPlace).IsRequired().HasMaxLength(50);

            builder.HasMany(c => c.Matches).WithOne(p => p.Championship).HasForeignKey(p => p.ChampionshipId);
            builder.HasMany(c => c.MatchesResult).WithOne(p => p.VwChampionship).HasForeignKey(p => p.ChampionshipId);
            //builder.Ignore(ign => ign.VwMatches);
        }
    }
}
