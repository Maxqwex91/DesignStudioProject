using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityConfiguration
{
    internal sealed class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");
            builder.HasKey(country => country.Id);
            builder.Property(country => country.Id).ValueGeneratedOnAdd();

            builder.HasMany(country => country.Offices)
                .WithOne(office => office.Country)
                .HasForeignKey(office => office.CountryId);
        }
    }
}