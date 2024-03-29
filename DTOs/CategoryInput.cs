namespace No1B.DTOs;

public class CategoryInput
{
    public Guid? Id { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }
}