using Microsoft.AspNetCore.Identity;
using No1B.DTOs;

namespace No1B.Repositories;

public interface IRoleRepository : IBaseRepository<IdentityRole, RoleOutput>
{
    //Task<Response<CategoryOutput>> GetCategoryByNameAsync(string name);

    //Task<Response<CategoryOutput>> AddCategoryAsync(CategoryInput input);

    //Task<Response<CategoryOutput>> UpdateCategoryAsync(CategoryInput input);
}