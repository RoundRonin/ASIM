using Domain.Entities;

namespace Infrastructure.Repositories;

public interface IRepairRepository
{
    Task<IEnumerable<RepairRequest>> GetAllRepairsAsync(int? repairStatusId);
    Task<RepairRequest> GetRepairByIdAsync(int repairId);
    Task<RepairRequest> CreateRepairAsync(RepairRequest repair);
    Task<RepairRequest> AcceptRepairAsync(int repairId, int repairmanId);
    Task<RepairRequest> CloseRepairAsync(int repairId, string reportNote);
}