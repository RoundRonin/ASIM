namespace Domain.Entities;

public class RepairRequest
{
    public int RequestId { get; init; }
    public string Description { get; init; }
    public string Status {  get; init; }
    public DateTime CreatedDate { get; init; }
    public DateTime UpdatedDate { get; init; }
    public int ObjectId { get; init; }
    public InventoryObject InventoryObject { get; init; }
    public int CreatedById { get; init; }
    public User CreatedBy { get; init; }
}