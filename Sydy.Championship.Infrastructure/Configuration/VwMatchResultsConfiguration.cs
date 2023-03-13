using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sydy.Championship.CoreBusiness.Entities;

namespace Sydy.Championship.Infrastructure.Configuration
{
    public class VwMatchResultsConfiguration : IEntityTypeConfiguration<VwMatchResultsModel>
    {
        public void Configure (EntityTypeBuilder<VwMatchResultsModel> builder)
        {
            builder.ToTable("VwChampionshipResults");
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Teams);
            builder.Property(c => c.Results);
            builder.Property(c => c.Date);
            builder.Property(c => c.ChampionshipId);

        }
    }
}
