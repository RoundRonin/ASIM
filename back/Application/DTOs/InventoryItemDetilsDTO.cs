namespace Application.DTOs;

public class InventoryItemDetailsDTO
{
    public string Description { get; set; }
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public DateTime PurchaseDate { get; set; }
    public string Warranty { get; set; }
    public string TechnicalSpecifications { get; set; }
}