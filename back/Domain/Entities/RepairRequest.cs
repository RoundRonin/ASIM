namespace Domain.Entities;

public class RepairRequest
{
    public int RequestId { get; set; }
    public int ItemId { get; set; } 
    public int CreatorId { get; set; }
    public int? RepairmanId { get; set; }
    public DateTime? EstimatedEndDate { get; set; }
    public string ReportNote { get; set; } = string.Empty;
    public string Status { get; set; } = "open";
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; }
}