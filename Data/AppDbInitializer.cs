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
                new Category(Guid.NewGuid(), "Book", "Book Category"),
                new Category(Guid.NewGuid(), "Photo", "Photo Category"),
            };

            db.Categories.AddRange(categoriesToAdd);
            db.SaveChanges();
        }
    }


    //private async Task SeedCategories(string filePath)
    //{
    //    if (await _categoryRepository.GetCountAsync() <= 0)
    //    {
    //        var jsonText = await File.ReadAllTextAsync(filePath);
    //        var categories = JsonConvert.DeserializeObject<List<Category>>(jsonText);

    //        foreach (var category in categories.Select(data =>
    //                     new Category(_guidGenerator.Create(), data.Name, data.Description)))
    //        {
    //            await _categoryRepository.InsertAsync(category);
    //        }

    //        var categoryDataCount = await _categoryRepository.GetCountAsync();
    //        var expectedCategoryCount = categories.Count;

    //        if (categoryDataCount == expectedCategoryCount)
    //        {
    //            var timeNow = DateTime.Now.ToString("HH:mm:ss");
    //            Console.WriteLine($"{timeNow} | SEED: Categories OK - Added {categoryDataCount} records");
    //        }
    //    }
    //}
}