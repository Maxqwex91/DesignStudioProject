using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityConfiguration
{
    internal class EmployeeStackTechnologyConfiguration : IEntityTypeConfiguration<EmployeeStackTechnology>
    {
        public void Configure(EntityTypeBuilder<EmployeeStackTechnology> builder)
        {
            builder.ToTable("EmployeeStackTechnologies");
            builder.HasKey(employeeStackTechnology => new
                { employeeStackTechnology.EmployeeId, employeeStackTechnology.StackTechnologyId });

            builder.HasOne(employeeStackTechnology => employeeStackTechnology.Employee)
                .WithMany(employee => employee.EmployeeStackTechnologies)
                .HasForeignKey(employeeStackTechnology => employeeStackTechnology.EmployeeId);

            builder.HasOne(employeeStackTechnology => employeeStackTechnology.StackTechnology)
                .WithMany(stackTechnology=> stackTechnology.EmployeeStackTechnologies)
                .HasForeignKey(employeeStackTechnology => employeeStackTechnology.StackTechnologyId);
        }
    }
}
