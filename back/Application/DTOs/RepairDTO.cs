namespace Application.DTOs;

public class RepairDTO
{
    public int RepairId { get; set; }       // maps from RequestId
    public int ItemId { get; set; }
    public int CreatorId { get; set; }
    public int? RepairmanId { get; set; }
    public DateTime? EstimatedEndDate { get; set; }
    public string ReportNote { get; set; }
}