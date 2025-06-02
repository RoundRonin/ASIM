using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Configurations;

public class RentalEntityTypeConfiguration : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.HasKey(r => r.RentalId);
        builder.Property(r => r.Status).HasMaxLength(50);

        builder.HasOne(r => r.Renter)
            .WithMany(u => u.Rentals)
            .HasForeignKey(r => r.RenterId);

        builder.HasOne(r => r.InventoryObject)
            .WithMany(o => o.Rentals)
            .HasForeignKey(r => r.ItemId);
    }
}