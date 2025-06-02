namespace Domain.Entities;

// TODO remove (sample entity) 

public class Order
{
    public int Id { get; init; }
    public string SenderCity { get; init; } = string.Empty;
    public string SenderAddress { get; init; } = string.Empty;
    public string ReceiverCity { get; init; } = string.Empty;
    public string ReceiverAddress { get; init; } = string.Empty;
    public double CargoWeight { get; init; }
    public DateTime PickupDate { get; init; }
    public string OrderNumber { get; init; } = string.Empty;


    public bool IsValid(out List<string> errors)
    {
        errors = [];

        if (PickupDate < DateTime.Now)
            errors.Add("Pickup date cannot be in the past.");

        if (CargoWeight <= 0)
            errors.Add("Cargo weight must be positive.");

        return errors.Count == 0;
    }
}
