namespace Domain.Entities;

public class AdditionalObjectDetails
{
    public int DetailsId { get; init; }
    public int ObjectId { get; init; }  // FK to InventoryObject

    public string Description { get; init; }
    public string Model { get; init; }
    public string Manufacturer { get; init; }
    public DateTime PurchaseDate { get; init; }
    public string Warranty { get; init; }
    public string TechnicalSpecifications { get; init; }

    public InventoryObject InventoryObject { get; init; }  // Navigation property
}
