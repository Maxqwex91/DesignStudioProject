using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DAL.EntityConfiguration
{
    internal sealed class StackTechnologyConfiguration : IEntityTypeConfiguration<StackTechnology>
    {
        public void Configure(EntityTypeBuilder<StackTechnology> builder)
        {
            builder.ToTable("StackTechnologies");
            builder.HasKey(stackTechnology => stackTechnology.Id);
            builder.Property(stackTechnology => stackTechnology.Id).ValueGeneratedOnAdd();

            builder.HasMany(stackTechnology => stackTechnology.EmployeeStackTechnologies)
                .WithOne(employeeStackTechnology => employeeStackTechnology.StackTechnology)
                .HasForeignKey(employeeStackTechnology => employeeStackTechnology.StackTechnologyId);
        }
    }
}