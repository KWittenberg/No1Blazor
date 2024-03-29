namespace No1B.Entities;

public class Category : BaseAuditableEntity<Guid>
{
    protected Category() { }

    public Category(Guid id, string name, string? description)
    {
        SetName(name);

        SetDescription(description);
    }

    public string Name { get; private set; }

    public string? Description { get; private set; }


    public void SetName(string name)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name), CategoryConsts.NameLength);
    }

    public void SetDescription(string? description)
    {
        Description = Check.NotNullOrWhiteSpace(description, nameof(description), CategoryConsts.DescriptionLength);
    }
}




//public abstract class Category : BaseAuditableEntity<Guid>
//{
//    protected Category() { }

//    public static T Create<T>(string name, string? description) where T : Category, new()
//    {
//        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

//        return new T
//        {
//            Name = name,
//            Description = description,
//        };
//    }

//    public string Name { get; private set; } = string.Empty;

//    public string? Description { get; private set; }
//}