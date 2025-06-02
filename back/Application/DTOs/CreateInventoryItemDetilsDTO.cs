namespace Application.DTOs;

public class CreateInventoryItemDetailsDTO
{
    public string Description { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public DateTime PurchaseDate { get; set; }
    public string Warranty { get; set; } = string.Empty;
    public string TechnicalSpecifications { get; set; } = string.Empty;
}