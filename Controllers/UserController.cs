using Microsoft.AspNetCore.Mvc;
using No1B.DTOs;
using No1B.Repositories;

namespace No1B.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController(IUserRepository repository) : ControllerBase
{
    [HttpGet("Users")]
    public async Task<ActionResult<Response<List<UserOutput>>>> GetCategories()
    {
        return Ok(await repository.GetAllAsync());
    }

    [HttpGet("User")]
    public async Task<ActionResult<Response<UserOutput>>> GetCategory(Guid id)
    {
        return Ok(await repository.GetByIdAsync(id));
    }

    //[HttpGet("Name")]
    //public async Task<ActionResult<Response<UserOutput>>> GetCategoryByName(string name)
    //{
    //    return Ok(await repository.GetCategoryByNameAsync(name));
    //}

    //[HttpPost("Add")]
    //public async Task<ActionResult<Response<UserOutput>>> AddCategory(CategoryInput input)
    //{
    //    return Ok(await repository.AddCategoryAsync(input));
    //}

    //[HttpPost("Update")]
    //public async Task<ActionResult<Response<UserOutput>>> UpdateCategory(CategoryInput input)
    //{
    //    return Ok(await repository.UpdateCategoryAsync(input));
    //}

    [HttpDelete("Delete")]
    public async Task<ActionResult<Response<UserOutput>>> DeleteCategory(Guid id)
    {
        return Ok(await repository.DeleteAsync(id));
    }
}