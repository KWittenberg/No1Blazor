using Microsoft.AspNetCore.Mvc;
using No1B.DTOs;
using No1B.Repositories;

namespace No1B.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserRepository repository) : ControllerBase
{
    [HttpGet("GetCurrentUserId")]
    public OkObjectResult GetCurrentUserId()
    {
        return Ok(repository.GetCurrentUserId());
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<Response<List<UserOutput>>>> GetAll()
    {
        return Ok(await repository.GetUsersWithRolesAsync());
    }

    //[HttpGet("Get")]
    //public async Task<ActionResult<Response<UserOutput>>> Get(Guid id)
    //{
    //    return Ok(await repository.GetByIdAsync(id));
    //}

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

    //[HttpDelete("Delete")]
    //public async Task<ActionResult<Response<UserOutput>>> Delete(Guid id)
    //{
    //    return Ok(await repository.DeleteAsync(id));
    //}
}