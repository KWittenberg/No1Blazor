using No1B.DTOs;
using No1B.Entities;

namespace No1B.Repositories;

public interface ICategoryRepository : IBaseRepository<Category, CategoryOutput>
{
    Task<Response<CategoryOutput>> GetCategoryByNameAsync(string name);

    Task<Response<CategoryOutput>> AddCategoryAsync(CategoryInput input);

    Task<Response<CategoryOutput>> UpdateCategoryAsync(CategoryInput input);
}

//public interface ICategoryRepository
//{
//    Task<Response<List<CategoryOutput>>> GetCategoriesAsync();

//    Task<Response<CategoryOutput>> GetCategoryAsync(Guid id);

//    Task<Response<CategoryOutput>> GetCategoryByNameAsync(string name);

//    Task<Response<CategoryOutput>> AddCategoryAsync(CategoryInput input);

//    Task<Response<CategoryOutput>> UpdateCategoryAsync(CategoryInput input);

//    Task<Response<CategoryOutput>> DeleteCategoryAsync(Guid id);
//}