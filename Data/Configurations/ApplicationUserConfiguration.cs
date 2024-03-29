using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using No1B.Entities;

namespace No1B.Data.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName).HasMaxLength(ApplicationUserConsts.FirstName);

        builder.Property(x => x.LastName).HasMaxLength(ApplicationUserConsts.LastName);

        builder.Property(x => x.AvatarUrl).HasMaxLength(ApplicationUserConsts.AvatarUrlLength);

        builder.Property(x => x.Country).HasMaxLength(ApplicationUserConsts.CountryLength);

        builder.Property(x => x.Zip).HasMaxLength(ApplicationUserConsts.ZipLength);

        builder.Property(x => x.City).HasMaxLength(ApplicationUserConsts.CityLength);

        builder.Property(x => x.Street).HasMaxLength(ApplicationUserConsts.StreetLength);
    }
}