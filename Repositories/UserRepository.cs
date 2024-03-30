using No1B.Data;
using No1B.DTOs;
using No1B.Entities;

namespace No1B.Repositories;

public class UserRepository(ApplicationDbContext db) : BaseRepository<ApplicationUser, UserOutput>(db), IUserRepository
{
    //public async Task<Response<CategoryOutput>> GetCategoryByNameAsync(string name)
    //{
    //    var entity = await db.Categories.FirstOrDefaultAsync(x => x.Name == name);
    //    if (entity is null) return ResponseHelper.ErrorResponse<CategoryOutput>(ResponseStatus.NotFound, "Entity Not Found!");

    //    return ResponseHelper.CreateResponse(ResponseStatus.OK, "OK", entity.Adapt<CategoryOutput>());
    //}

    //public async Task<Response<CategoryOutput>> AddCategoryAsync(CategoryInput input)
    //{
    //    var entity = await db.Categories.FirstOrDefaultAsync(x => x.Name == input.Name);
    //    if (entity is not null) return ResponseHelper.ErrorResponse<CategoryOutput>(ResponseStatus.Forbidden, "Entity Exists!");

    //    entity = new Category(Guid.NewGuid(), input.Name, input.Description);

    //    await db.Categories.AddAsync(entity);
    //    await db.SaveChangesAsync();

    //    return ResponseHelper.CreateResponse(ResponseStatus.OK, "OK", entity.Adapt<CategoryOutput>());
    //}

    //public async Task<Response<CategoryOutput>> UpdateCategoryAsync(CategoryInput input)
    //{
    //    var entity = await db.Categories.FindAsync(input.Id);
    //    if (entity is null) return ResponseHelper.ErrorResponse<CategoryOutput>(ResponseStatus.NotFound, "Entity Not Found!");

    //    entity.SetName(input.Name);
    //    entity.SetDescription(input.Description);

    //    db.Categories.Update(entity);
    //    await db.SaveChangesAsync();

    //    return ResponseHelper.CreateResponse(ResponseStatus.OK, "OK", entity.Adapt<CategoryOutput>());
    //}
}