using No1B.DTOs;

namespace No1B.Repositories;

public interface ICategoryRepository
{
    Task<Response<List<CategoryOutput>>> GetCategoriesAsync();

    Task<Response<CategoryOutput>> GetCategoryAsync(Guid id);

    Task<Response<CategoryOutput>> GetCategoryByNameAsync(string name);

    Task<Response<CategoryOutput>> AddCategoryAsync(CategoryInput input);

    Task<Response<CategoryOutput>> UpdateCategoryAsync(CategoryInput input);
}