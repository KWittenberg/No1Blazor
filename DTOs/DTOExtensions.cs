using No1B.Entities;

namespace No1B.DTOs;

public static class DTOExtensions
{
    public static CategoryDTO ToModel(this Category category) => new CategoryDTO(category.Id, category.Name, category.Description);
}
