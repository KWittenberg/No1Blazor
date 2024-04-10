using No1B.DTOs;

namespace No1B.Repositories;

public interface IUserRepository
{
    Guid GetCurrentUserId();

    Task<Response<List<UserOutput>>> GetUsersWithRolesAsync();

    //Task<Response<CategoryOutput>> GetCategoryByNameAsync(string name);

    //Task<Response<CategoryOutput>> AddCategoryAsync(CategoryInput input);

    //Task<Response<CategoryOutput>> UpdateCategoryAsync(CategoryInput input);
}