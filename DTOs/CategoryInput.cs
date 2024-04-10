using System.ComponentModel.DataAnnotations;

namespace No1B.DTOs;

public class CategoryInput
{
    [Required(ErrorMessage = "Name is required!")]
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? IconHtml { get; set; }
}