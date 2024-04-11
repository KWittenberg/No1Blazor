using No1B.DTOs;

namespace No1B.Repositories;

public interface IUserRepository
{
    Guid GetCurrentUserId();

    Task<Response<List<UserOutput>>> GetUsersWithRolesAsync();

    Task<Response<UserOutput>> GetByIdAsync(Guid id);
}