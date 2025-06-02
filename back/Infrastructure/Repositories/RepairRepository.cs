using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RepairRepository(AppDbContext context) : IRepairRepository
{
    public async Task<IEnumerable<RepairRequest>> GetAllRepairsAsync(int? repairStatusId)
    {
        IQueryable<RepairRequest> query = context.RepairRequests;
        // If you want to filter by status (if repairStatusId maps to a status code), do so here.
        // For this example, we simply return all repair records.
        return await query.ToListAsync();
    }
        
    public async Task<RepairRequest> GetRepairByIdAsync(int repairId)
    {
        return await context.RepairRequests.FirstOrDefaultAsync(r => r.RequestId == repairId);
    }
        
    public async Task<RepairRequest> CreateRepairAsync(RepairRequest repair)
    {
        await context.RepairRequests.AddAsync(repair);
        await context.SaveChangesAsync();
        return repair;
    }
        
    public async Task<RepairRequest> AcceptRepairAsync(int repairId, int repairmanId)
    {
        var repair = await context.RepairRequests.FirstOrDefaultAsync(r => r.RequestId == repairId);
        if (repair != null)
        {
            repair.RepairmanId = repairmanId;
            repair.Status = "accepted";
            repair.UpdatedDate = DateTime.UtcNow;
            await context.SaveChangesAsync();
        }
        return repair;
    }
        
    public async Task<RepairRequest> CloseRepairAsync(int repairId, string reportNote)
    {
        var repair = await context.RepairRequests.FirstOrDefaultAsync(r => r.RequestId == repairId);
        if (repair != null)
        {
            repair.ReportNote = reportNote;
            repair.Status = "closed";
            repair.UpdatedDate = DateTime.UtcNow;
            await context.SaveChangesAsync();
        }
        return repair;
    }
}