using Application.DTOs;

namespace Application.Interfaces;

public interface IInventoryService
{
    Task<InventoryItemDTO> GetItemInfoByIdAsync(Guid itemId);
    Task<IEnumerable<InventoryItemDTO>> GetItemsByTypeAsync(int? itemTypeId);
    Task<InventoryItemDTO> GetItemByIdAsync(Guid itemId);
    Task<InventoryItemDTO> AddNewItemAsync(CreateInventoryItemDTO createInventoryItemDTO);
    Task DeleteItemAsync(Guid itemId);
}