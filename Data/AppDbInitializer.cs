using No1B.Entities;

namespace No1B.Data;

public class AppDbInitializer
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
        var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

        db.Database.EnsureCreated();

        if (!db.Categories.Any())
        {
            var categoriesToAdd = new List<Category>()
            {
                new Category(Guid.NewGuid(), "Book", "Book Category", "<i class=\"bi bi-book\"></i>"),
                new Category(Guid.NewGuid(), "Photo", "Photo Category", "<i class=\"bi bi-file-earmark-image\"></i>"),
            };

            db.Categories.AddRange(categoriesToAdd);
            db.SaveChanges();
        }
    }
}