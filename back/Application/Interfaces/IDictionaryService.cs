using Application.DTOs;

namespace Application.Interfaces;

public interface IDictionaryService
{
    Task<IEnumerable<DictionaryItemDTO>> GetItemTypesAsync();
    Task<IEnumerable<DictionaryItemDTO>> GetItemStatusesAsync();
    Task<IEnumerable<DictionaryItemDTO>> GetRepairStatusesAsync();
    Task<IEnumerable<DictionaryItemDTO>> GetRentStatusesAsync();
}
