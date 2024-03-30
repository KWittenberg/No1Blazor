using No1B.Data;

namespace No1B.Repositories;

internal abstract class Repository<TEntity>(ApplicationDbContext db) where TEntity : class
{
    protected readonly ApplicationDbContext Db = db;

    public void Add(TEntity entity)
    {
        Db.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
        Db.Set<TEntity>().Update(entity);
    }

    public void Remove(TEntity entity)
    {
        Db.Set<TEntity>().Remove(entity);
    }
}