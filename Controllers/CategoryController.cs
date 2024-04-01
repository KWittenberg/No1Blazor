using Microsoft.AspNetCore.Mvc;
using No1B.DTOs;
using No1B.Repositories;

namespace No1B.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoryController(ICategoryRepository repository) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<Response<List<CategoryOutput>>>> GetAll()
    {
        return Ok(await repository.GetAllAsync());
    }

    [HttpGet("Get")]
    public async Task<ActionResult<Response<CategoryOutput>>> Get(Guid id)
    {
        return Ok(await repository.GetByIdAsync(id));
    }

    [HttpGet("GetByName")]
    public async Task<ActionResult<Response<CategoryOutput>>> GetByName(string name)
    {
        return Ok(await repository.GetCategoryByNameAsync(name));
    }

    [HttpPost("Add")]
    public async Task<ActionResult<Response<CategoryOutput>>> Add(CategoryInput input)
    {
        return Ok(await repository.AddCategoryAsync(input));
    }

    [HttpPost("Update")]
    public async Task<ActionResult<Response<CategoryOutput>>> Update(CategoryInput input)
    {
        return Ok(await repository.UpdateCategoryAsync(input));
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<Response<CategoryOutput>>> Delete(Guid id)
    {
        return Ok(await repository.DeleteAsync(id));
    }
}