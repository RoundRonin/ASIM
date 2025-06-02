using Application.DTOs;

namespace Application.Interfaces;

public interface IRepairService
{
    Task<IEnumerable<RepairDTO>> GetAllRepairsAsync(int? repairStatusId);
    Task<RepairDTO> GetRepairByIdAsync(int repairId);
    Task<RepairDTO> CreateRepairAsync(CreateRepairDTO createRepairDTO);
    Task<RepairDTO> AcceptRepairAsync(int repairId, AcceptRepairDTO acceptRepairDTO);
    Task<RepairDTO> CloseRepairAsync(int repairId, CloseRepairDTO closeRepairDTO);
}