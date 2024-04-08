using No1B.Data;

namespace No1B.Repositories;

internal abstract class Repository<TEntity>(ApplicationDbContext db) where TEntity : class
{
    protected readonly ApplicationDbContext _db = db;

    public void Add(TEntity entity)
    {
        _db.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
        _db.Set<TEntity>().Update(entity);
    }

    public void Remove(TEntity entity)
    {
        _db.Set<TEntity>().Remove(entity);
    }
}