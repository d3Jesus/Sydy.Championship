using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sydy.Championship.CoreBusiness.Entities;

namespace Sydy.Championship.Infrastructure.Configuration
{
    public class TeamConfiguration : IEntityTypeConfiguration<TeamModel>
    {
        public void Configure(EntityTypeBuilder<TeamModel> builder)
        {
            builder.ToTable("Team");
            builder.Property(t => t.Id).IsRequired();
            builder.Property(t => t.Name).IsRequired().HasMaxLength(50);
        }
    }
}
