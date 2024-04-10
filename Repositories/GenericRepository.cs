using Microsoft.EntityFrameworkCore;
using No1B.Data;

namespace No1B.Repositories;

internal abstract class GenericRepository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _db;
    private readonly DbSet<T> _entity = null;

    protected GenericRepository(ApplicationDbContext db)
    {
        _db = db;
        _entity = _db.Set<T>();
    }


    public async Task<IList<T>> GetAll()
    {
        return await _entity.ToListAsync();
    }

    public async Task<T> Get(Guid id)
    {
        return await _entity.FindAsync(id);
    }

    public bool Add(T input)
    {
        try
        {
            _entity.AddAsync(input);
            _db.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Update(T input)
    {
        try
        {
            _entity.Update(input);
            _db.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Delete(T input)
    {
        try
        {
            _entity.Remove(input);
            _db.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}