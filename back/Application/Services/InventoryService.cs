using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;
        
        public InventoryService(IInventoryRepository inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }
        
        public async Task<InventoryItemDTO> GetItemInfoByIdAsync(Guid itemId)
        {
            var item = await _inventoryRepository.GetItemInfoByIdAsync(itemId);
            if (item == null)
            {
                return null;
            }
            return _mapper.Map<InventoryItemDTO>(item);
        }
        
        public async Task<IEnumerable<InventoryItemDTO>> GetItemsByTypeAsync(int? itemTypeId)
        {
            var items = await _inventoryRepository.GetItemsByTypeAsync(itemTypeId);
            return _mapper.Map<IEnumerable<InventoryItemDTO>>(items);
        }
        
        public async Task<InventoryItemDTO> GetItemByIdAsync(Guid itemId)
        {
            var item = await _inventoryRepository.GetByIdAsync(itemId);
            if (item == null)
            {
                return null;
            }
            return _mapper.Map<InventoryItemDTO>(item);
        }
        
        public async Task<InventoryItemDTO> AddNewItemAsync(CreateInventoryItemDTO createInventoryItemDTO)
        {
            var item = _mapper.Map<InventoryObject>(createInventoryItemDTO);
            item = await _inventoryRepository.AddAsync(item);
            return _mapper.Map<InventoryItemDTO>(item);
        }
        
        public async Task DeleteItemAsync(Guid itemId)
        {
            await _inventoryRepository.DeleteAsync(itemId);
        }
    }
}
