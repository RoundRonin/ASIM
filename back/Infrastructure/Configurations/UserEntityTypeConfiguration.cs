using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Infrastructure.Configurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.UserId);
        builder.Property(e => e.Name).HasMaxLength(100);
        builder.Property(e => e.Email).HasMaxLength(100);
        builder.Property(e => e.PasswordHash).HasMaxLength(256);
        builder.Property(e => e.Role).HasMaxLength(50);

        builder.HasMany(e => e.BlacklistEntries)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.Rentals)
            .WithOne(r => r.Renter)
            .HasForeignKey(r => r.RenterId);

        builder.HasMany(e => e.RepairRequests)
            .WithOne() 
            .HasForeignKey(r => r.CreatorId);

        builder.HasMany(e => e.LogEntries)
            .WithOne(l => l.User)
            .HasForeignKey(l => l.UserId);
    }
}