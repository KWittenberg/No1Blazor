using No1B.DTOs;

namespace No1B.Repositories;

public interface ICategoryRepository
{
    Task<Response<List<CategoryOutput>>> GetAllAsync();

    Task<Response<CategoryOutput>> GetByIdAsync(Guid id);

    Task<Response<CategoryOutput>> GetByNameAsync(string name);

    Task<Response<CategoryOutput>> AddAsync(CategoryInput input);

    Task<Response<CategoryOutput>> UpdateAsync(Guid id, CategoryInput input);

    Task<Response<CategoryOutput>> DeleteAsync(Guid id);
}