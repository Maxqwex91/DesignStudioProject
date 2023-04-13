using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityConfiguration
{
    internal sealed class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Offices");
            builder.HasKey(office => office.Id);
            builder.Property(office => office.Id).ValueGeneratedOnAdd();

            builder.HasMany(office => office.Employees)
                .WithOne(employee => employee.Office)
                .HasForeignKey(employee => employee.OfficeId);

            builder.HasOne(office => office.Country)
                .WithMany(country => country.Offices)
                .HasForeignKey(office => office.CountryId);
        }
    }
}
