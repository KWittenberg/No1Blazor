using Microsoft.AspNetCore.Mvc;
using No1B.DTOs;
using No1B.Repositories;

namespace No1B.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoryController(ICategoryRepository categoryRepository) : ControllerBase
{
    [HttpGet("Categories")]
    public async Task<ActionResult<Response<List<CategoryOutput>>>> GetCategories()
    {
        return Ok(await categoryRepository.GetCategoriesAsync());
    }

    [HttpGet("Category")]
    public async Task<ActionResult<Response<CategoryOutput>>> GetCategory(Guid id)
    {
        return Ok(await categoryRepository.GetCategoryAsync(id));
    }

    [HttpGet("Name")]
    public async Task<ActionResult<Response<CategoryOutput>>> GetCategoryByName(string name)
    {
        return Ok(await categoryRepository.GetCategoryByNameAsync(name));
    }

    [HttpPost("Add")]
    public async Task<ActionResult<Response<CategoryOutput>>> AddCategory(CategoryInput input)
    {
        return Ok(await categoryRepository.AddCategoryAsync(input));
    }

    [HttpPost("Update")]
    public async Task<ActionResult<Response<CategoryOutput>>> UpdateCategory(CategoryInput input)
    {
        return Ok(await categoryRepository.UpdateCategoryAsync(input));
    }

    //[HttpDelete("admin/{id}"), Authorize(Roles = "Admin")]
    //public async Task<ActionResult<ServiceResponse<List<Category>>>> DeleteCategory(int id)
    //{
    //    var result = await _categoryService.DeleteCategory(id);
    //    return Ok(result);
    //}
}