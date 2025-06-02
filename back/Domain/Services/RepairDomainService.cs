using Domain.Entities;
using Infrastructure.Repositories;

namespace Domain.Services;

public class RepairDomainService(IRepairRepository repairRepository) : IRepairDomainService
{
    private readonly IRepairRepository _repairRepository = repairRepository;

    public async Task<IEnumerable<RepairRequest>> GetAllRepairsAsync(int? repairStatusId)
    {
        // Optionally filter by repairStatusId if your statuses are numeric codes.
        return await _repairRepository.GetAllRepairsAsync(repairStatusId);
    }
        
    public async Task<RepairRequest> GetRepairByIdAsync(int repairId)
    {
        return await _repairRepository.GetRepairByIdAsync(repairId);
    }
        
    public async Task<RepairRequest> CreateRepairAsync(RepairRequest repair)
    {
        repair.Status = "open";
        return await _repairRepository.CreateRepairAsync(repair);
    }
        
    public async Task<RepairRequest> AcceptRepairAsync(int repairId, int repairmanId)
    {
        return await _repairRepository.AcceptRepairAsync(repairId, repairmanId);
    }
        
    public async Task<RepairRequest> CloseRepairAsync(int repairId, string reportNote)
    {
        return await _repairRepository.CloseRepairAsync(repairId, reportNote);
    }
}