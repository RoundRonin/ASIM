namespace Domain.Entities;

public class Rental
{
    public int RentalId { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public string Status { get; init; }

    public int ObjectId { get; init; }
    public InventoryObject InventoryObject { get; init; }

    public int RenterId { get; init; }
    public User Renter { get; init; }
}