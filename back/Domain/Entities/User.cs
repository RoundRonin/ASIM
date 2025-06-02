namespace Domain.Entities;

public class User
{
    public int UserId { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
    public string PasswordHash { get; init; }
    public string Role { get; init; }
    public DateTime LastLogin { get; init; }

    public ICollection<Rental> Rentals { get; init; } = new List<Rental>();
    public ICollection<RepairRequest> RepairRequests { get; init; } = new List<RepairRequest>();
    public ICollection<LogEntry> LogEntries { get; init; } = new List<LogEntry>();
    public ICollection<BlacklistEntry> BlacklistEntries { get; init; } = new List<BlacklistEntry>();
}
