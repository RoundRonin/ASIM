using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Configurations;

public class RepairRequestEntityTypeConfiguration : IEntityTypeConfiguration<RepairRequest>
{
    public void Configure(EntityTypeBuilder<RepairRequest> builder)
    {
        builder.HasKey(r => r.RequestId);
        builder.Property(r => r.ReportNote)
            .HasColumnType("text");
        builder.Property(r => r.Status)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(r => r.ItemId)
            .IsRequired();
        builder.Property(r => r.CreatorId)
            .IsRequired();
        builder.Property(r => r.RepairmanId);
        builder.Property(r => r.EstimatedEndDate);
        builder.Property(r => r.CreatedDate)
            .IsRequired();
        builder.Property(r => r.UpdatedDate);
    }
}