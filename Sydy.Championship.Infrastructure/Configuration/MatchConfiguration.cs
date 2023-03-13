using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sydy.Championship.CoreBusiness.Entities;

namespace Sydy.Championship.Infrastructure.Configuration
{
    public class MatchConfiguration : IEntityTypeConfiguration<MatchModel>
    {
        public void Configure(EntityTypeBuilder<MatchModel> builder)
        {
            builder.ToTable("Match");
            builder.Property(m => m.Id).IsRequired();
            builder.Property(m => m.FirstTeamId).IsRequired().HasMaxLength(50);
            builder.Property(m => m.FirstTeamGoals).IsRequired();
            builder.Property(m => m.SecondTeamId).IsRequired().HasMaxLength(50);
            builder.Property(m => m.SecondTeamGoals).IsRequired();
            builder.Property(m => m.Date).IsRequired();
            builder.Property(m => m.ChampionshipId).IsRequired();
        }
    }
}
