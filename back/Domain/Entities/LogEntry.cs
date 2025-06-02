namespace Domain.Entities;

public class LogEntry
{
    public int LogId { get; init; }
    public string Action { get; init; }
    public DateTime Timestamp { get; init; }
    public string Description { get; init; }

    public int UserId { get; init; }
    public User User { get; init; }

    public Guid ItemId { get; init; }
    public InventoryObject InventoryObject { get; init; }
}