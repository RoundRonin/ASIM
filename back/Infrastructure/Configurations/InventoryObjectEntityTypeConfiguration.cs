using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Configurations;

public class InventoryObjectEntityTypeConfiguration : IEntityTypeConfiguration<InventoryObject>
{
    public void Configure(EntityTypeBuilder<InventoryObject> builder)
    {
        builder.HasKey(o => o.ItemId);
        builder.Property(o => o.Name).HasMaxLength(100);
        builder.Property(o => o.SerialNumber).HasMaxLength(100);
        builder.Property(o => o.Location).HasMaxLength(100);
        builder.Property(o => o.Condition).HasMaxLength(50);
        builder.Property(o => o.QrCode).HasMaxLength(100);

        builder.HasOne(o => o.AdditionalDetails)
            .WithOne(d => d.InventoryObject)
            .HasForeignKey<AdditionalObjectDetails>(d => d.ItemId);
    }
}