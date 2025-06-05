using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class CreateInventoryItemDTO
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Serial number is required.")]
    public string SerialNumber { get; set; } = string.Empty;
        
    public string Location { get; set; } = string.Empty;
    public string Condition { get; set; } = string.Empty;
    public string QrCode { get; set; } = string.Empty;
        
    public int? ItemTypeId { get; set; }
        
    public CreateInventoryItemDetailsDTO AdditionalDetails { get; set; }
}