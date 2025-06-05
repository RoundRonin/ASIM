using Domain.Entities;

namespace Domain.Interfaces;

public interface IInventoryDomainService
{
    Task<InventoryObject> GetItemInfoByIdAsync(Guid itemId);
    Task<IEnumerable<InventoryObject>> GetItemsByTypeAsync(int? itemTypeId);
    Task<InventoryObject> GetItemByIdAsync(Guid itemId);
    Task<InventoryObject> AddNewItemAsync(InventoryObject newItem);
    Task DeleteItemAsync(Guid itemId);
}