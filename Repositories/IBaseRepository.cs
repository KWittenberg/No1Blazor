using No1B.DTOs;

namespace No1B.Repositories;

public interface IBaseRepository<T, TOutput>
{
    Task<Response<List<TOutput>>> GetAllAsync();

    Task<Response<TOutput>> GetByIdAsync(Guid id);

    Task<Response<TOutput>> GetByNameAsync(string name);

    Task<Response<TOutput>> DeleteAsync(Guid id);
}