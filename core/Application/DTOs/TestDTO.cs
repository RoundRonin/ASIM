namespace Application.DTOs;

public class TestDTO : CreateTestDTO
{
    public required int Id { get; set; }
    public required string Text { get; set; }
}
