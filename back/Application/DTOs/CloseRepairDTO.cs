using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class CloseRepairDTO
{
    [Required]
    public string ReportNote { get; set; }
}