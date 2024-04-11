using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using No1B.Data.Configurations;
using No1B.Entities;
using System.Security.Claims;

namespace No1B.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor contextAccessor) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Category> Categories { get; set; }



    // pogledati i prebaciti konfiguraciju baze
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
    //    .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FootballLeague_EfCore; Encrypt=true", sqlOptions => { sqlOptions
    //        .EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null);
    //});

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());

        modelBuilder.ApplyConfiguration(new CategoryConfiguration());

        // Add Other Configurations       
    }

    private Guid GetCurrentUserId() => Guid.Parse(contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? Guid.Empty.ToString());

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseAuditableEntity<Guid>>()
                     .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            entry.Entity.LastModifiedUtc = DateTime.Now;
            entry.Entity.LastModifiedId = GetCurrentUserId();

            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedUtc = DateTime.Now;
                entry.Entity.CreatedId = GetCurrentUserId();
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }


    //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    //{
    //    var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseAuditableEntity<Guid> && (e.State == EntityState.Added || e.State == EntityState.Modified));

    //    foreach (var entityEntry in entries)
    //    {
    //        switch (entityEntry.State)
    //        {
    //            case EntityState.Added:
    //                ((BaseAuditableEntity<Guid>)entityEntry.Entity).CreatedUtc = DateTime.Now;
    //                break;
    //            case EntityState.Modified:
    //                ((BaseAuditableEntity<Guid>)entityEntry.Entity).LastModifiedUtc = DateTime.Now;
    //                break;
    //            default:
    //                break;
    //        }
    //    }
    //    return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    //}
}