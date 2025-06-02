using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class InventoryRepository(AppDbContext context) : IInventoryRepository
{
    public async Task<InventoryObject> GetByIdAsync(Guid itemId)
    {
        return await context.InventoryObjects
            .Include(io => io.AdditionalDetails)
            .FirstOrDefaultAsync(io => io.ItemId == itemId);
    }
        
    public async Task<InventoryObject> GetItemInfoByIdAsync(Guid itemId)
    {
        // For this example, assume the "item info" is the same as the full entity.
        return await GetByIdAsync(itemId);
    }
        
    public async Task<IEnumerable<InventoryObject>> GetItemsByTypeAsync(int? itemTypeId)
    {
        IQueryable<InventoryObject> query = context.InventoryObjects.Include(io => io.AdditionalDetails);
        if (itemTypeId.HasValue)
        {
            query = query.Where(io => io.ItemTypeId == itemTypeId.Value);
        }
        return await query.ToListAsync();
    }
        
    public async Task<InventoryObject> AddAsync(InventoryObject item)
    {
        await context.InventoryObjects.AddAsync(item);
        await context.SaveChangesAsync();
        return item;
    }
        
    public async Task DeleteAsync(Guid itemId)
    {
        var entity = await context.InventoryObjects.FirstOrDefaultAsync(io => io.ItemId == itemId);
        if (entity != null)
        {
            context.InventoryObjects.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}