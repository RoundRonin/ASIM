using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class DictionaryRepository : IDictionaryRepository
{
    public async Task<IEnumerable<DictionaryItem>> GetItemTypesAsync() =>
        await Task.FromResult(new List<DictionaryItem>
        {
            new() { Id = 1, Code = "laptop", Name = "Laptop" },
            new() { Id = 2, Code = "printer", Name = "Printer" }
        });

    public async Task<IEnumerable<DictionaryItem>> GetItemStatusesAsync() =>
        await Task.FromResult(new List<DictionaryItem>
        {
            new() { Id = 1, Code = "available", Name = "Available" },
            new() { Id = 2, Code = "in_use", Name = "In Use" }
        });

    public async Task<IEnumerable<DictionaryItem>> GetRepairStatusesAsync() =>
        await Task.FromResult(new List<DictionaryItem>
        {
            new() { Id = 1, Code = "open", Name = "Открыта" },
            new() { Id = 2, Code = "in_progress", Name = "В ремонте" },
            new() { Id = 3, Code = "closed", Name = "Закрыта" }
        });

    public async Task<IEnumerable<DictionaryItem>> GetRentStatusesAsync() =>
        await Task.FromResult(new List<DictionaryItem>
        {
            new() { Id = 1, Code = "open", Name = "Открыта" },
            new() { Id = 2, Code = "closed", Name = "Закрыта" }
        });
}
