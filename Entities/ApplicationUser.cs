using Microsoft.AspNetCore.Identity;

namespace No1B.Entities;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; } = string.Empty;

    public string? LastName { get; set; } = string.Empty;

    public string? AvatarUrl { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; }

    public string? Country { get; set; } = string.Empty;

    public string? Zip { get; set; } = string.Empty;

    public string? City { get; set; } = string.Empty;

    public string? Street { get; set; } = string.Empty;
}