using No1B.DTOs;
using No1B.Entities;

namespace No1B.Repositories;

public interface IUserRepository : IBaseRepository<ApplicationUser, UserOutput>
{
    //Task<Response<CategoryOutput>> GetCategoryByNameAsync(string name);

    //Task<Response<CategoryOutput>> AddCategoryAsync(CategoryInput input);

    //Task<Response<CategoryOutput>> UpdateCategoryAsync(CategoryInput input);
}