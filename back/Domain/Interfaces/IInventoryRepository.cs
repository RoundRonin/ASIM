using Domain.Entities;

namespace Domain.Interfaces;

public interface IInventoryRepository
{
    Task<InventoryObject> GetByIdAsync(Guid itemId);
    Task<InventoryObject> GetItemInfoByIdAsync(Guid itemId);
    Task<IEnumerable<InventoryObject>> GetItemsByTypeAsync(int? itemTypeId);
    Task<InventoryObject> AddAsync(InventoryObject item);
    Task DeleteAsync(Guid itemId);
}