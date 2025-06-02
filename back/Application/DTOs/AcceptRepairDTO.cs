using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class AcceptRepairDTO
{
    [Required]
    public int RepairmanId { get; set; }
}