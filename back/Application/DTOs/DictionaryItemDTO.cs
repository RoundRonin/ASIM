namespace Application.DTOs;

public class DictionaryItemDTO
{
    public int ItemStatusId { get; set; } // Will be mapped from DictionaryItem.Id
    public string Code { get; set; }
    public string Name { get; set; }
}
