namespace Domain.Entities;

public class BlacklistEntry
{
    public int BlacklistId { get; init; }
    public int UserId { get; init; }
    public DateTime RevokedAt { get; init; }
    public string Reason { get; init; }

    public User User { get; init; }
}