using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Services;
public class RentDomainService(IRentRepository rentRepository) : IRentDomainService
{
    public async Task<Rental> CreateRentAsync(Rental rent)
    {
        rent.Status = "open";
        return await rentRepository.CreateRentAsync(rent);
    }

    public async Task<IEnumerable<Rental>> GetAllRentsAsync(string status)
    {
        return await rentRepository.GetAllRentsAsync(status);
    }

    public async Task<Rental> GetRentByIdAsync(int rentId)
    {
        return await rentRepository.GetRentByIdAsync(rentId);
    }

    public async Task SetRentStatusAsync(int rentId, string status)
    {
        await rentRepository.SetRentStatusAsync(rentId, status);
    }
}
