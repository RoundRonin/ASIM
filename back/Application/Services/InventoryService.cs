using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class InventoryService(IInventoryDomainService inventoryDomainService, IMapper mapper)
    : IInventoryService
{
    public async Task<InventoryItemDTO> GetItemInfoByIdAsync(Guid itemId)
    {
        var item = await inventoryDomainService.GetItemInfoByIdAsync(itemId);
        return item == null ? null : mapper.Map<InventoryItemDTO>(item);
    }
        
    public async Task<IEnumerable<InventoryItemDTO>> GetItemsByTypeAsync(int? itemTypeId)
    {
        var items = await inventoryDomainService.GetItemsByTypeAsync(itemTypeId);
        return mapper.Map<IEnumerable<InventoryItemDTO>>(items);
    }
        
    public async Task<InventoryItemDTO> GetItemByIdAsync(Guid itemId)
    {
        var item = await inventoryDomainService.GetItemByIdAsync(itemId);
        return item == null ? null : mapper.Map<InventoryItemDTO>(item);
    }
        
    public async Task<InventoryItemDTO> AddNewItemAsync(CreateInventoryItemDTO createInventoryItemDTO)
    {
        var item = mapper.Map<InventoryObject>(createInventoryItemDTO);
        item = await inventoryDomainService.AddNewItemAsync(item);
        return mapper.Map<InventoryItemDTO>(item);
    }
        
    public async Task DeleteItemAsync(Guid itemId)
    {
        await inventoryDomainService.DeleteItemAsync(itemId);
    }
}