using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;

namespace Application.Services;

public class DictionaryService(IDictionaryRepository repository, IMapper mapper) : IDictionaryService
{
    public async Task<IEnumerable<DictionaryItemDTO>> GetItemTypesAsync()
    {
        var items = await repository.GetItemTypesAsync();
        return mapper.Map<IEnumerable<DictionaryItemDTO>>(items);
    }

    public async Task<IEnumerable<DictionaryItemDTO>> GetItemStatusesAsync()
    {
        var items = await repository.GetItemStatusesAsync();
        return mapper.Map<IEnumerable<DictionaryItemDTO>>(items);
    }

    public async Task<IEnumerable<DictionaryItemDTO>> GetRepairStatusesAsync()
    {
        var items = await repository.GetRepairStatusesAsync();
        return mapper.Map<IEnumerable<DictionaryItemDTO>>(items);
    }

    public async Task<IEnumerable<DictionaryItemDTO>> GetRentStatusesAsync()
    {
        var items = await repository.GetRentStatusesAsync();
        return mapper.Map<IEnumerable<DictionaryItemDTO>>(items);
    }
}
