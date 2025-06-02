using Microsoft.EntityFrameworkCore;
using Infrastructure.Configurations; 
using Domain.Entities;

namespace Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<BlacklistEntry> BlacklistEntries { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<RepairRequest> RepairRequests { get; set; }
    public DbSet<InventoryObject> InventoryObjects { get; set; }
    public DbSet<AdditionalObjectDetails> AdditionalObjectDetails { get; set; }
    public DbSet<LogEntry> LogEntries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}