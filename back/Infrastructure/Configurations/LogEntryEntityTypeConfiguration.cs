using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Configurations;

public class LogEntryEntityTypeConfiguration : IEntityTypeConfiguration<LogEntry>
{
    public void Configure(EntityTypeBuilder<LogEntry> builder)
    {
        builder.HasKey(l => l.LogId);
        builder.Property(l => l.Action).HasMaxLength(255);
        builder.Property(l => l.Timestamp);
        builder.Property(l => l.Description).HasColumnType("text");

        builder.HasOne(l => l.User)
            .WithMany(u => u.LogEntries)
            .HasForeignKey(l => l.UserId);

        builder.HasOne(l => l.InventoryObject)
            .WithMany(o => o.LogEntries)
            .HasForeignKey(l => l.ItemId);
    }
}