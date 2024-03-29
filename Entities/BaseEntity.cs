namespace No1B.Entities;

public abstract class BaseEntity<TKey>
{
    public TKey Id { get; set; }
}