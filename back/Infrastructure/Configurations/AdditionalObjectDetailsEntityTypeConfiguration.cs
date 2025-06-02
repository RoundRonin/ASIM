using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Configurations;

public class AdditionalObjectDetailsEntityTypeConfiguration : IEntityTypeConfiguration<AdditionalObjectDetails>
{
    public void Configure(EntityTypeBuilder<AdditionalObjectDetails> builder)
    {
        builder.HasKey(d => d.DetailsId);
        builder.Property(d => d.Description).HasColumnType("text");
        builder.Property(d => d.Model).HasMaxLength(100);
        builder.Property(d => d.Manufacturer).HasMaxLength(100);
        builder.Property(d => d.PurchaseDate).HasColumnType("date");
        builder.Property(d => d.Warranty).HasMaxLength(100);
        builder.Property(d => d.TechnicalSpecifications).HasColumnType("text");

        builder.HasOne(d => d.InventoryObject)
            .WithOne(o => o.AdditionalDetails)
            .HasForeignKey<AdditionalObjectDetails>(d => d.ItemId);
    }
}