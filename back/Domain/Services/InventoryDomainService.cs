using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Services;

public class InventoryDomainService(IInventoryRepository inventoryRepository) : IInventoryDomainService
{
    public async Task<InventoryObject> GetItemInfoByIdAsync(Guid itemId)
    {
        // Add any business logic or validations as necessary
        return await inventoryRepository.GetItemInfoByIdAsync(itemId);
    }

    public async Task<IEnumerable<InventoryObject>> GetItemsByTypeAsync(int? itemTypeId)
    {
        // Business logic to filter might go here
        return await inventoryRepository.GetItemsByTypeAsync(itemTypeId);
    }

    public async Task<InventoryObject> GetItemByIdAsync(Guid itemId)
    {
        return await inventoryRepository.GetByIdAsync(itemId);
    }

    public async Task<InventoryObject> AddNewItemAsync(InventoryObject newItem)
    {
        // Perform business validations or actions here before saving.
        // For example: Check for duplicate serial numbers, etc.
        return await inventoryRepository.AddAsync(newItem);
    }

    public async Task DeleteItemAsync(Guid itemId)
    {
        await inventoryRepository.DeleteAsync(itemId);
    }
}