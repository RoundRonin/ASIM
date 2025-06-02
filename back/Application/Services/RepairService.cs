using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;

namespace Application.Services;

public class RepairService(IRepairDomainService repairDomainService, IMapper mapper) : IRepairService
{
    public async Task<IEnumerable<RepairDTO>> GetAllRepairsAsync(int? repairStatusId)
    {
        var repairs = await repairDomainService.GetAllRepairsAsync(repairStatusId);
        return mapper.Map<IEnumerable<RepairDTO>>(repairs);
    }
        
    public async Task<RepairDTO> GetRepairByIdAsync(int repairId)
    {
        var repair = await repairDomainService.GetRepairByIdAsync(repairId);
        return mapper.Map<RepairDTO>(repair);
    }
        
    public async Task<RepairDTO> CreateRepairAsync(CreateRepairDTO createRepairDTO)
    {
        var repair = mapper.Map<RepairRequest>(createRepairDTO);
        var createdRepair = await repairDomainService.CreateRepairAsync(repair);
        return mapper.Map<RepairDTO>(createdRepair);
    }
        
    public async Task<RepairDTO> AcceptRepairAsync(int repairId, AcceptRepairDTO acceptRepairDTO)
    {
        var acceptedRepair = await repairDomainService.AcceptRepairAsync(repairId, acceptRepairDTO.RepairmanId);
        return mapper.Map<RepairDTO>(acceptedRepair);
    }
        
    public async Task<RepairDTO> CloseRepairAsync(int repairId, CloseRepairDTO closeRepairDTO)
    {
        var closedRepair = await repairDomainService.CloseRepairAsync(repairId, closeRepairDTO.ReportNote);
        return mapper.Map<RepairDTO>(closedRepair);
    }
}