namespace No1B.DTOs;

public class UserOutput
{
    public Guid Id { get; set; }

    public string? UserName { get; set; } = string.Empty;

    public string? FirstName { get; set; } = string.Empty;

    public string? LastName { get; set; } = string.Empty;

    public string? Email { get; set; } = string.Empty;

    public string? AvatarUrl { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; }

    public string? Country { get; set; } = string.Empty;

    public string? Zip { get; set; } = string.Empty;

    public string? City { get; set; } = string.Empty;

    public string? Street { get; set; } = string.Empty;
}