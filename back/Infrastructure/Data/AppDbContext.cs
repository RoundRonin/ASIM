using Microsoft.EntityFrameworkCore;
using Infrastructure.Configurations;
using Domain.Entities;

namespace Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Order> Orders { get; set; } // пример

    public DbSet<User> Users { get; set; }
    public DbSet<BlacklistEntry> BlacklistEntries { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<RepairRequest> RepairRequests { get; set; }
    public DbSet<InventoryObject> InventoryObjects { get; set; }
    public DbSet<AdditionalObjectDetails> AdditionalObjectDetails { get; set; }
    public DbSet<LogEntry> LogEntries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(256);
            entity.Property(e => e.Role).HasMaxLength(50);

            entity.HasMany(e => e.BlacklistEntries)
                  .WithOne(b => b.User)
                  .HasForeignKey(b => b.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(e => e.Rentals)
                  .WithOne(r => r.Renter)
                  .HasForeignKey(r => r.RenterId);

            entity.HasMany(e => e.RepairRequests)
                  .WithOne(r => r.CreatedBy)
                  .HasForeignKey(r => r.CreatedById);

            entity.HasMany(e => e.LogEntries)
                  .WithOne(l => l.User)
                  .HasForeignKey(l => l.UserId);
        });

        modelBuilder.Entity<BlacklistEntry>(entity =>
        {
            entity.HasKey(b => b.BlacklistId);
            entity.Property(b => b.RevokedAt);
            entity.Property(b => b.Reason).HasMaxLength(255);
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasKey(r => r.RentalId);
            entity.Property(r => r.Status).HasMaxLength(50);

            entity.HasOne(r => r.Renter)
                  .WithMany(u => u.Rentals)
                  .HasForeignKey(r => r.RenterId);

            entity.HasOne(r => r.InventoryObject)
                  .WithMany(o => o.Rentals)
                  .HasForeignKey(r => r.ObjectId);
        });

        modelBuilder.Entity<RepairRequest>(entity =>
        {
            entity.HasKey(r => r.RequestId);
            entity.Property(r => r.Description).HasColumnType("text");
            entity.Property(r => r.Status).HasMaxLength(50);

            entity.HasOne(r => r.CreatedBy)
                  .WithMany(u => u.RepairRequests)
                  .HasForeignKey(r => r.CreatedById);

            entity.HasOne(r => r.InventoryObject)
                  .WithMany(o => o.RepairRequests)
                  .HasForeignKey(r => r.ObjectId);
        });

        modelBuilder.Entity<InventoryObject>(entity =>
        {
            entity.HasKey(o => o.ObjectId);
            entity.Property(o => o.Name).HasMaxLength(100);
            entity.Property(o => o.SerialNumber).HasMaxLength(100);
            entity.Property(o => o.Location).HasMaxLength(100);
            entity.Property(o => o.Condition).HasMaxLength(50);
            entity.Property(o => o.QrCode).HasMaxLength(100);

            entity.HasOne(o => o.AdditionalDetails)
                  .WithOne(d => d.InventoryObject)
                  .HasForeignKey<AdditionalObjectDetails>(d => d.ObjectId);
        });

        modelBuilder.Entity<LogEntry>(entity =>
        {
            entity.HasKey(l => l.LogId);
            entity.Property(l => l.Action).HasMaxLength(255);
            entity.Property(l => l.Timestamp);
            entity.Property(l => l.Description).HasColumnType("text");

            entity.HasOne(l => l.User)
                  .WithMany(u => u.LogEntries)
                  .HasForeignKey(l => l.UserId);

            entity.HasOne(l => l.InventoryObject)
                  .WithMany(o => o.LogEntries)
                  .HasForeignKey(l => l.ObjectId);
        });

        modelBuilder.Entity<AdditionalObjectDetails>(entity =>
        {
            entity.HasKey(d => d.DetailsId);
            entity.Property(d => d.Description).HasColumnType("text");
            entity.Property(d => d.Model).HasMaxLength(100);
            entity.Property(d => d.Manufacturer).HasMaxLength(100);
            entity.Property(d => d.PurchaseDate).HasColumnType("date");
            entity.Property(d => d.Warranty).HasMaxLength(100);
            entity.Property(d => d.TechnicalSpecifications).HasColumnType("text");
        });
        modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
    }
}
