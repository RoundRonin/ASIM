using Domain.Entities;

namespace Domain.Interfaces;

public interface IDictionaryRepository
{
    Task<IEnumerable<DictionaryItem>> GetItemTypesAsync();
    Task<IEnumerable<DictionaryItem>> GetItemStatusesAsync();
    Task<IEnumerable<DictionaryItem>> GetRepairStatusesAsync();
    Task<IEnumerable<DictionaryItem>> GetRentStatusesAsync();
}
