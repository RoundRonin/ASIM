using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Configurations;

public class BlacklistEntryEntityTypeConfiguration : IEntityTypeConfiguration<BlacklistEntry>
{
    public void Configure(EntityTypeBuilder<BlacklistEntry> builder)
    {
        builder.HasKey(b => b.BlacklistId);
        // Assuming RevokedAt is configured as needed by default.
        builder.Property(b => b.Reason).HasMaxLength(255);
    }
}