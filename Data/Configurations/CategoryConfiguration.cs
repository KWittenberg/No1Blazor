using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using No1B.Entities;

namespace No1B.Data.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(CategoryConsts.NameLength).IsRequired();

        builder.Property(x => x.Description).HasMaxLength(CategoryConsts.DescriptionLength);

        builder.Property(x => x.IconHtml).HasMaxLength(CategoryConsts.IconHtmlLength);
    }
}