namespace No1B.Entities;

public class Category : BaseAuditableEntity<Guid>
{
    protected Category() { }

    public Category(Guid id, string name, string? description, string? iconHtml)
    {
        SetName(name);

        SetDescription(description);

        SetIconHtml(iconHtml);
    }

    public string Name { get; private set; } = string.Empty;

    public string? Description { get; private set; }

    public string? IconHtml { get; private set; }


    public void SetName(string name)
    {
        Name = Check.NotNullOrWhiteSpace(name, nameof(name), CategoryConsts.NameLength);
    }

    public void SetDescription(string? description)
    {
        Description = Check.NotNullOrWhiteSpace(description, nameof(description), CategoryConsts.DescriptionLength);
    }

    public void SetIconHtml(string? iconHtml)
    {
        IconHtml = Check.NotNullOrWhiteSpace(iconHtml, nameof(iconHtml), CategoryConsts.IconHtmlLength);
    }
}