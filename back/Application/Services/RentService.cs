using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class RentService(IRentDomainService rentDomainService, IMapper mapper) : IRentService
{
    public async Task<RentDTO> CreateRentAsync(CreateRentDTO createRentDTO)
    {
        var rent = mapper.Map<Rental>(createRentDTO);
        var createdRent = await rentDomainService.CreateRentAsync(rent);
        return mapper.Map<RentDTO>(createdRent);
    }

    public async Task<IEnumerable<RentDTO>> GetAllRentsAsync(string status)
    {
        var rents = await rentDomainService.GetAllRentsAsync(status);
        return mapper.Map<IEnumerable<RentDTO>>(rents);
    }

    public async Task<RentDTO> GetRentByIdAsync(int rentId)
    {
        var rent = await rentDomainService.GetRentByIdAsync(rentId);
        return mapper.Map<RentDTO>(rent);
    }

    public async Task SetRentStatusAsync(int rentId, UpdateRentStatusDTO updateStatusDTO)
    {
        await rentDomainService.SetRentStatusAsync(rentId, updateStatusDTO.Status);
    }
}
