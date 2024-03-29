using Mapster;
using Microsoft.EntityFrameworkCore;
using No1B.Data;
using No1B.DTOs;
using No1B.Entities;
using No1B.Enums;

namespace No1B.Repositories;

public class CategoryRepository(ApplicationDbContext db) : ICategoryRepository
{
    public async Task<Response<List<CategoryOutput>>> GetCategoriesAsync()
    {
        var categories = await db.Categories.ToListAsync();
        if (categories.Count == 0) return Response<List<CategoryOutput>>(ResponseStatus.NotFound, "Categories Not Found!", null);

        //var response = categories
        //    .Select(c => new CategoryOutput
        //    {
        //        Id = c.Id,
        //        Name = c.Name,
        //        Description = c.Description

        //    }).ToList();
        var response = categories.Adapt<List<CategoryOutput>>();

        return Response(ResponseStatus.OK, "OK", response);
    }

    public async Task<Response<CategoryOutput>> GetCategoryAsync(Guid id)
    {
        var category = await db.Categories.FindAsync(id);
        if (category is null) return Response<CategoryOutput>(ResponseStatus.NotFound, "Category Not Found!", null);

        //var data = new CategoryOutput() { Id = category.Id, Name = category.Name, Description = category.Description };
        var data = category.Adapt<CategoryOutput>();

        return Response(ResponseStatus.OK, "OK", data);
    }

    public async Task<Response<CategoryOutput>> GetCategoryByNameAsync(string name)
    {
        var category = await db.Categories.FirstOrDefaultAsync(x => x.Name == name);
        if (category is null) return Response<CategoryOutput>(ResponseStatus.NotFound, "Category Name Not Found!", null);

        var data = category.Adapt<CategoryOutput>();

        return Response(ResponseStatus.OK, "OK", data);
    }

    public async Task<Response<CategoryOutput>> AddCategoryAsync(CategoryInput input)
    {
        var response = await GetCategoryByNameAsync(input.Name);
        if (response.Status == ResponseStatus.OK) return Response<CategoryOutput>(ResponseStatus.Forbidden, "Category Exists!", response.Data);

        var category = new Category(Guid.NewGuid(), input.Name, input.Description);

        await db.Categories.AddAsync(category);
        await db.SaveChangesAsync();

        //var data = new CategoryOutput() { Id = category.Id, Name = category.Name, Description = category.Description };
        var data = category.Adapt<CategoryOutput>();

        return Response(ResponseStatus.OK, "OK", data);
    }

    public async Task<Response<CategoryOutput>> UpdateCategoryAsync(CategoryInput input)
    {
        var category = await db.Categories.FindAsync(input.Id);
        if (category is null) return Response<CategoryOutput>(ResponseStatus.NotFound, "Category Not Found!", null);

        category.SetName(input.Name);
        category.SetDescription(input.Description);

        db.Categories.Update(category);
        await db.SaveChangesAsync();

        return Response(ResponseStatus.OK, "OK", category.Adapt<CategoryOutput>());
    }









    private Response<T> Response<T>(ResponseStatus status, string message, T? data)
    {
        return new Response<T> { Status = status, Message = message, Data = data };
    }










    //public async Task<ProductCategoryViewModel> UpdateProductCategoryAsync(ProductCategoryUpdateBinding model)
    //{
    //    var dbo = await db.ProductCategory.FindAsync(model.Id);
    //    mapper.Map(model, dbo);
    //    await db.SaveChangesAsync();
    //    return mapper.Map<ProductCategoryViewModel>(dbo);
    //}
}