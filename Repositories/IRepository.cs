namespace No1B.Repositories;

public interface IRepository<T> where T : class
{
    Task<IList<T>> GetAll();

    Task<T> Get(Guid id);

    bool Add(T input);

    bool Update(T input);

    bool Delete(T input);
}