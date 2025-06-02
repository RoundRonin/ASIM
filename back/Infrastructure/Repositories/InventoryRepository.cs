using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly AppDbContext _context;
        
        public InventoryRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<InventoryObject> GetByIdAsync(Guid itemId)
        {
            return await _context.InventoryObjects
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
            IQueryable<InventoryObject> query = _context.InventoryObjects.Include(io => io.AdditionalDetails);
            if (itemTypeId.HasValue)
            {
                query = query.Where(io => io.ItemTypeId == itemTypeId.Value);
            }
            return await query.ToListAsync();
        }
        
        public async Task<InventoryObject> AddAsync(InventoryObject item)
        {
            await _context.InventoryObjects.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }
        
        public async Task DeleteAsync(Guid itemId)
        {
            var entity = await _context.InventoryObjects.FirstOrDefaultAsync(io => io.ItemId == itemId);
            if (entity != null)
            {
                _context.InventoryObjects.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
