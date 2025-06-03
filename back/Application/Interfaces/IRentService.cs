using Application.DTOs;

namespace Application.Interfaces;

public interface IRentService
{
    Task<RentDTO> CreateRentAsync(CreateRentDTO createRentDTO);
    Task<IEnumerable<RentDTO>> GetAllRentsAsync(string status);
    Task<RentDTO> GetRentByIdAsync(int rentId);
    Task SetRentStatusAsync(int rentId, UpdateRentStatusDTO updateStatusDTO);
}
