namespace Domain.Entities;

public class PaginatedList<T>
{
    public List<T> Items { get; init; } = [];
    public int TotalItems { get; init; }
    public int TotalPages { get; init; }
    public int CurrentPage { get; init; }
}
