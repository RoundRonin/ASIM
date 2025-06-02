
namespace Application.DTOs;

public class InventoryItemDTO
{
    public Guid ItemId { get; set; }
    public string Name { get; set; }
    public string SerialNumber { get; set; }
    public string Location { get; set; }
    public string Condition { get; set; }
    public string QrCode { get; set; }
    public InventoryItemDetailsDTO Details { get; set; }
}