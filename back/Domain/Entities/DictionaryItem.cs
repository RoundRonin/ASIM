namespace Domain.Entities;

public class DictionaryItem
{
    public int Id { get; set; }         // Previously: ItemStatusId
    public string Code { get; set; }
    public string Name { get; set; }
}
