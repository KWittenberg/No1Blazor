using Mapster;
using Microsoft.EntityFrameworkCore;
using No1B.Data;
using No1B.DTOs;
using No1B.Entities;
using No1B.Enums;

namespace No1B.Repositories;

public class CategoryRepository(ApplicationDbContext db) : ICategoryRepository
{
    public async Task<Response<List<CategoryOutput>>> GetAllAsync()
    {
        var entities = await db.Categories.AsNoTracking().ToListAsync();
        if (entities.Count == 0) return ResponseHelper.CreateResponse<List<CategoryOutput>>(HttpStatusCode.NotFound, "Entities Not Found!", null);
        var outputs = entities.Adapt<List<CategoryOutput>>();

        return ResponseHelper.CreateResponse(HttpStatusCode.OK, "OK", outputs);
    }

    public async Task<Response<CategoryOutput>> GetByIdAsync(Guid id)
    {
        var entity = await db.Categories.FindAsync(id);
        if (entity is null) return ResponseHelper.ErrorResponse<CategoryOutput>(HttpStatusCode.NotFound, "Entity not found");
        var output = entity.Adapt<CategoryOutput>();

        return ResponseHelper.CreateResponse(HttpStatusCode.OK, "OK", output);
    }

    public async Task<Response<CategoryOutput>> GetByNameAsync(string name)
    {
        var entity = await db.Categories.FirstOrDefaultAsync(x => x.Name == name);
        if (entity is null) return ResponseHelper.ErrorResponse<CategoryOutput>(HttpStatusCode.NotFound, "Entity Not Found!");

        return ResponseHelper.CreateResponse(HttpStatusCode.OK, "OK", entity.Adapt<CategoryOutput>());
    }

    public virtual async Task<Response<CategoryOutput>> AddAsync(CategoryInput input)
    {
        var entity = await db.Categories.FirstOrDefaultAsync(x => x.Name == input.Name);
        if (entity is not null) return ResponseHelper.ErrorResponse<CategoryOutput>(HttpStatusCode.Forbidden, "Entity Exists!");

        entity = new Category(Guid.NewGuid(), input.Name, input.Description, input.IconHtml);

        await db.Categories.AddAsync(entity);
        await db.SaveChangesAsync();

        return ResponseHelper.CreateResponse(HttpStatusCode.OK, "OK", entity.Adapt<CategoryOutput>());
    }

    public virtual async Task<Response<CategoryOutput>> UpdateAsync(Guid id, CategoryInput input)
    {
        var entity = await db.Categories.FindAsync(id);
        if (entity is null) return ResponseHelper.ErrorResponse<CategoryOutput>(HttpStatusCode.NotFound, "Entity Not Found!");

        entity.SetName(input.Name);
        entity.SetDescription(input.Description);
        entity.SetIconHtml(input.IconHtml);

        db.Categories.Update(entity);
        await db.SaveChangesAsync();

        return ResponseHelper.CreateResponse(HttpStatusCode.OK, "OK", entity.Adapt<CategoryOutput>());
    }

    public async Task<Response<CategoryOutput>> DeleteAsync(Guid id)
    {
        var entity = await db.Categories.FindAsync(id);
        if (entity == null) return ResponseHelper.ErrorResponse<CategoryOutput>(HttpStatusCode.NotFound, "Entity not found");

        db.Categories.Remove(entity);
        await db.SaveChangesAsync();

        var output = entity.Adapt<CategoryOutput>();

        return ResponseHelper.CreateResponse(HttpStatusCode.OK, "OK", output);
    }
}


// Orginal CategoryRepository Bez upotrebe BaseRepository
//
//public class CategoryRepository(ApplicationDbContext db) : ICategoryRepository
//{
//    public async Task<Response<List<CategoryOutput>>> GetCategoriesAsync()
//    {
//        var categories = await db.Categories.ToListAsync();
//        if (categories.Count == 0) return Response<List<CategoryOutput>>(ResponseStatus.NotFound, "Categories Not Found!", null);

//        //var response = categories
//        //    .Select(c => new CategoryOutput
//        //    {
//        //        Id = c.Id,
//        //        Name = c.Name,
//        //        Description = c.Description

//        //    }).ToList();
//        var response = categories.Adapt<List<CategoryOutput>>();

//        return Response(ResponseStatus.OK, "OK", response);
//    }

//    public async Task<Response<CategoryOutput>> GetCategoryAsync(Guid id)
//    {
//        var category = await db.Categories.FindAsync(id);
//        if (category is null) return Response<CategoryOutput>(ResponseStatus.NotFound, "Category Not Found!", null);

//        //var data = new CategoryOutput() { Id = category.Id, Name = category.Name, Description = category.Description };
//        var data = category.Adapt<CategoryOutput>();

//        return Response(ResponseStatus.OK, "OK", data);
//    }

//    public async Task<Response<CategoryOutput>> GetCategoryByNameAsync(string name)
//    {
//        var category = await db.Categories.FirstOrDefaultAsync(x => x.Name == name);
//        if (category is null) return Response<CategoryOutput>(ResponseStatus.NotFound, "Category Name Not Found!", null);

//        var data = category.Adapt<CategoryOutput>();

//        return Response(ResponseStatus.OK, "OK", data);
//    }

//    public async Task<Response<CategoryOutput>> AddCategoryAsync(CategoryInput input)
//    {
//        var response = await GetCategoryByNameAsync(input.Name);
//        if (response.Status == ResponseStatus.OK) return Response<CategoryOutput>(ResponseStatus.Forbidden, "Category Exists!", response.Data);

//        var category = new Category(Guid.NewGuid(), input.Name, input.Description);

//        await db.Categories.AddAsync(category);
//        await db.SaveChangesAsync();

//        //var data = new CategoryOutput() { Id = category.Id, Name = category.Name, Description = category.Description };
//        var data = category.Adapt<CategoryOutput>();

//        return Response(ResponseStatus.OK, "OK", data);
//    }

//    public async Task<Response<CategoryOutput>> UpdateCategoryAsync(CategoryInput input)
//    {
//        var category = await db.Categories.FindAsync(input.Id);
//        if (category is null) return Response<CategoryOutput>(ResponseStatus.NotFound, "Category Not Found!", null);

//        category.SetName(input.Name);
//        category.SetDescription(input.Description);

//        db.Categories.Update(category);
//        await db.SaveChangesAsync();

//        return Response(ResponseStatus.OK, "OK", category.Adapt<CategoryOutput>());
//    }

//    public async Task<Response<CategoryOutput>> DeleteCategoryAsync(Guid id)
//    {
//        var category = await db.Categories.FindAsync(id);
//        if (category is null) return Response<CategoryOutput>(ResponseStatus.NotFound, "Category Not Found!", null);

//        db.Categories.Remove(category);
//        await db.SaveChangesAsync();

//        return Response(ResponseStatus.OK, "OK", category.Adapt<CategoryOutput>());
//    }

//    private Response<T> Response<T>(ResponseStatus status, string message, T? data)
//    {
//        return new Response<T> { Status = status, Message = message, Data = data };
//    }
//}