using Microsoft.EntityFrameworkCore;
using Infrastructure.Configurations;
using Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Test> Tests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
    }
}