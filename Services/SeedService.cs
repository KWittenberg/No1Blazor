using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using No1B.Data;
using No1B.Entities;
using No1B.Options;

namespace No1B.Services;

public class SeedService(ApplicationDbContext db,
                            IOptions<AdminOptions> adminOptions,
                            IUserStore<ApplicationUser> userStore,
                            UserManager<ApplicationUser> userManager,
                            RoleManager<IdentityRole> roleManager) : ISeedService
{


    public async Task SeedAsync()
    {
#if DEBUG
        await MigrateDatabaseAsync();
#endif

        await SeedAdminRole();
        await SeedAdminUser();

        await SeedCategories("./Services/SeedData/Categories.json");
    }

    private async Task MigrateDatabaseAsync()
    {
        if ((await db.Database.GetPendingMigrationsAsync()).Any())
        {
            await db.Database.MigrateAsync();
        }
    }

    private async Task SeedAdminRole()
    {
        if (await roleManager.FindByNameAsync(ApplicationRole.Admin) is null)
        {
            var adminRole = new IdentityRole(ApplicationRole.Admin);
            var result = await roleManager.CreateAsync(adminRole);
            if (!result.Succeeded) throw new Exception($"Error in creating Role {Environment.NewLine}{string.Join(Environment.NewLine, result.Errors.Select(e => e.Description))}");

            var role = await roleManager.FindByNameAsync(ApplicationRole.Admin);
            var timeNow = DateTime.Now.ToString("HH:mm:ss");
            if (role is null) throw new Exception($"{timeNow} | Seed ROLE: Fail!");
            Console.WriteLine($"{timeNow} | Seed ROLE: OK - Added - {role?.Name} role!");
        }
    }

    private async Task SeedAdminUser()
    {
        var adminUser = await userManager.FindByEmailAsync(adminOptions.Value.Email);
        if (adminUser is null)
        {
            var adminRole = await roleManager.FindByNameAsync(ApplicationRole.Admin);
            if (adminRole is null) throw new Exception("Admin Role Not Found!");

            adminUser = new ApplicationUser();

            adminUser.FirstName = adminOptions.Value.FirstName;
            adminUser.LastName = adminOptions.Value.LastName;
            adminUser.DateOfBirth = new DateTime(1973, 10, 11);

            adminUser.Email = adminOptions.Value.Email;
            adminUser.EmailConfirmed = true;

            adminUser.PhoneNumber = adminOptions.Value.PhoneNumber;
            adminUser.PhoneNumberConfirmed = true;

            adminUser.AvatarUrl = adminOptions.Value.Avatar;
            adminUser.Country = adminOptions.Value.Country;
            adminUser.Zip = adminOptions.Value.Zip;
            adminUser.City = adminOptions.Value.City;
            adminUser.Street = adminOptions.Value.Street;

            await userStore.SetUserNameAsync(adminUser, adminOptions.Value.Email, CancellationToken.None);

            var result = await userManager.CreateAsync(adminUser, adminOptions.Value.Password);
            if (!result.Succeeded) throw new Exception($"Error in creating User {Environment.NewLine}{string.Join(Environment.NewLine, result.Errors.Select(e => e.Description))}");

            await userManager.AddToRoleAsync(adminUser, ApplicationRole.Admin);

            var user = await userManager.FindByEmailAsync(adminUser.Email);
            var timeNow = DateTime.Now.ToString("HH:mm:ss");
            if (user is null) throw new Exception($"{timeNow} | Seed USER: Fail!");

            var isInRoleAdmin = await userManager.IsInRoleAsync(user, ApplicationRole.Admin);
            Console.WriteLine($"{timeNow} | Seed USER: OK - Added - {user?.UserName} user with role Admin!");
        }
    }

    private async Task SeedCategories(string filePath)
    {
        if (!await db.Categories.AsNoTracking().AnyAsync())
        {
            var jsonText = await File.ReadAllTextAsync(filePath);
            var categories = JsonConvert.DeserializeObject<List<Category>>(jsonText);

            foreach (var category in categories.Select(data => new Category(Guid.NewGuid(), data.Name, data.Description, data.IconHtml)))
            {
                await db.Categories.AddAsync(category);
            }

            await db.SaveChangesAsync();
        }
    }
}