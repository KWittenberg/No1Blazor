using Microsoft.AspNetCore.Identity;
using No1B.Data;
using No1B.DTOs;

namespace No1B.Repositories;

public class RoleRepository(ApplicationDbContext db) : BaseRepository<IdentityRole, RoleOutput>(db), IRoleRepository
{
    //public async Task<Response<List<UserOutput>>> GetUsersWithRolesAsync()
    //{
    //    var entities = await db.Users.ToListAsync();
    //    if (entities.Count == 0) return ResponseHelper.CreateResponse<List<UserOutput>>(ResponseStatus.NotFound, "Entities Not Found!", null);

    //    var roles = await db.Roles.ToListAsync();


    //    return ResponseHelper.CreateResponse(ResponseStatus.OK, "OK", entities.Adapt<List<UserOutput>>());
    //}

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