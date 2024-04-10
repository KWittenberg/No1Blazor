using Mapster;
using Microsoft.EntityFrameworkCore;
using No1B.Data;
using No1B.DTOs;
using No1B.Enums;

namespace No1B.Repositories;

public class BaseRepository<T, TOutput>(ApplicationDbContext db) where T : class
{
    protected readonly ApplicationDbContext _db = db;


    public virtual async Task<Response<List<TOutput>>> GetAllAsync()
    {
        var entities = await _db.Set<T>().ToListAsync();
        if (entities.Count == 0) return ResponseHelper.CreateResponse<List<TOutput>>(HttpStatusCode.NotFound, "Entities Not Found!", null);
        var outputs = entities.Adapt<List<TOutput>>();

        return ResponseHelper.CreateResponse(HttpStatusCode.OK, "OK", outputs);
    }

    public virtual async Task<Response<TOutput>> GetByIdAsync(Guid id)
    {
        var entity = await _db.Set<T>().FindAsync(id);
        if (entity is null) return ResponseHelper.ErrorResponse<TOutput>(HttpStatusCode.NotFound, "Entity not found");
        var output = entity.Adapt<TOutput>();

        return ResponseHelper.CreateResponse(HttpStatusCode.OK, "OK", output);
    }

    public virtual async Task<Response<TOutput>> GetByNameAsync(string name)
    {
        var entity = await _db.Set<T>().FindAsync(name);
        if (entity is null) return ResponseHelper.ErrorResponse<TOutput>(HttpStatusCode.NotFound, "Entity not found");
        var output = entity.Adapt<TOutput>();

        return ResponseHelper.CreateResponse(HttpStatusCode.OK, "OK", output);
    }

    public virtual async Task<Response<TOutput>> DeleteAsync(Guid id)
    {
        var entity = await _db.Set<T>().FindAsync(id);
        if (entity == null) return ResponseHelper.ErrorResponse<TOutput>(HttpStatusCode.NotFound, "Entity not found");

        _db.Set<T>().Remove(entity);
        await _db.SaveChangesAsync();

        var output = entity.Adapt<TOutput>();

        return ResponseHelper.CreateResponse(HttpStatusCode.OK, "OK", output);
    }
}

//public virtual async Task<Response<TOutput>> AddAsync(TInput input)
//{
//    var entity = await db.Set<TEntity>().FindAsync(input.Name);
//    if (entity is null) return ResponseHelper.ErrorResponse<TOutput>(ResponseStatus.NotFound, "Entity not found");

//    entity = new <TEntity>(Guid.NewGuid(), input.Name, input.Description);

//    db.Set<TEntity>().Add(entity);
//    await db.SaveChangesAsync();

//    var output = entity.Adapt<TOutput>();
//    return ResponseHelper.CreateResponse(ResponseStatus.OK, "OK", output);
//}


//public async Task<Response<CategoryOutput>> AddCategoryAsync(CategoryInput input)
//{
//    var response = await GetCategoryByNameAsync(input.Name);
//    if (response.Status == ResponseStatus.OK) return Response<CategoryOutput>(ResponseStatus.Forbidden, "Category Exists!", response.Data);

//    var category = new Category(Guid.NewGuid(), input.Name, input.Description);

//    await db.Categories.AddAsync(category);
//    await db.SaveChangesAsync();

//    //var data = new CategoryOutput() { Id = category.Id, Name = category.Name, Description = category.Description };
//    var data = category.Adapt<CategoryOutput>();

//    return Response(ResponseStatus.OK, "OK", data);
//}


//public virtual async Task<Response<TOutput>> UpdateAsync(Guid id, TInput input)
//{
//    var entity = await _dbContext.Set<TEntity>().FindAsync(id);
//    if (entity == null)
//        return new Response<TOutput>(ResponseStatus.NotFound, "Entity not found", null);
//    entity = input.Adapt(entity);
//    await _dbContext.SaveChangesAsync();
//    var output = entity.Adapt<TOutput>();
//    return new Response<TOutput>(ResponseStatus.OK, "OK", output);
//}