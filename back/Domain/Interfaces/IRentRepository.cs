using Domain.Entities;

namespace Domain.Interfaces;

public interface IRentRepository
{
    Task<Rental> CreateRentAsync(Rental rent);
    Task<IEnumerable<Rental>> GetAllRentsAsync(string status);
    Task<Rental> GetRentByIdAsync(int rentId);
    Task SetRentStatusAsync(int rentId, string status);
}
