using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RentRepository(AppDbContext dbContext) : IRentRepository
{
    public async Task<Rental> CreateRentAsync(Rental rent)
    {
        dbContext.Rentals.Add(rent);
        await dbContext.SaveChangesAsync();
        return rent;
    }

    public async Task<IEnumerable<Rental>> GetAllRentsAsync(string status)
    {
        var query = dbContext.Rentals.AsQueryable();

        if (!string.IsNullOrWhiteSpace(status))
        {
            query = query.Where(r => r.Status == status);
        }

        return await query.ToListAsync();
    }

    public async Task<Rental> GetRentByIdAsync(int rentId)
    {
        return await dbContext.Rentals
            .FirstOrDefaultAsync(r => r.RentalId == rentId);
    }

    public async Task SetRentStatusAsync(int rentId, string status)
    {
        var rent = await dbContext.Rentals.FirstOrDefaultAsync(r => r.RentalId == rentId);
        if (rent == null) throw new Exception($"Rent with ID {rentId} not found.");

        rent.Status = status;
        await dbContext.SaveChangesAsync();
    }
}
