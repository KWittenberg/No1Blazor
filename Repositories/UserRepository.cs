using Mapster;
using Microsoft.EntityFrameworkCore;
using No1B.Data;
using No1B.DTOs;
using No1B.Entities;
using No1B.Enums;

namespace No1B.Repositories;

public class UserRepository(ApplicationDbContext db) : BaseRepository<ApplicationUser, UserOutput>(db), IUserRepository
{
    public async Task<Response<List<UserOutput>>> GetUsersWithRolesAsync()
    {
        var users = await db.Users.ToListAsync();
        if (users.Count == 0) return ResponseHelper.CreateResponse<List<UserOutput>>(HttpStatusCode.NotFound, "Users Not Found!", null);

        var usersWithRoles = users.Select(user =>
        {
            var userRoleIds = db.UserRoles.Where(ur => ur.UserId == user.Id).Select(ur => ur.RoleId).ToList();
            var userRoles = db.Roles.Where(r => userRoleIds.Contains(r.Id)).ToList();
            var userOutput = user.Adapt<UserOutput>();
            userOutput.Roles = userRoles.Select(r => r.Adapt<RoleOutput>()).ToList();

            return userOutput;
        }).ToList();

        return ResponseHelper.CreateResponse(HttpStatusCode.OK, "OK", usersWithRoles);
    }

    //public async Task<Response<List<UserOutput>>> GetUsersWithRolesAsyncNew()
    //{
    //    var usersWithRoles = await db.Users.Include(u => u.Roles).Select(user => new UserOutput
    //    {
    //        Id = user.Id,
    //        UserName = user.UserName,
    //        // Mapiranje ostalih svojstava prema potrebi
    //        Roles = user.UserRoles.Select(ur => ur.Role.Adapt<RoleOutput>()).ToList()
    //    })
    //        .ToListAsync();

    //    if (usersWithRoles.Count == 0)
    //        return ResponseHelper.CreateResponse<List<UserOutput>>(ResponseStatus.NotFound, "Users Not Found!", null);

    //    return ResponseHelper.CreateResponse(ResponseStatus.OK, "OK", usersWithRoles);
    //}

    //public async Task<Response<List<UserOutput>>> GetUsersWithRolesAsync2()
    //{
    //    var usersWithRoles = await db.Users
    //        .Join(db.UserRoles, user => user.Id, userRole => userRole.UserId, (user, userRole) => new { User = user, UserRole = userRole })
    //        .Join(db.Roles, combined => combined.UserRole.RoleId, role => role.Id, (combined, role) => new { User = combined.User, Role = role })
    //        .GroupBy(x => x.User)
    //        .Select(group => new UserOutput
    //        {
    //            Id = group.Key.Id,
    //            UserName = group.Key.UserName,
    //            Roles = group.Select(x => new RoleOutput { Id = x.Role.Id, Name = x.Role.Name }).ToList()
    //        })
    //        .ToListAsync();

    //    if (usersWithRoles.Count == 0)
    //        return ResponseHelper.CreateResponse<List<UserOutput>>(ResponseStatus.NotFound, "Users Not Found!", null);

    //    return ResponseHelper.CreateResponse(ResponseStatus.OK, "OK", usersWithRoles);
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