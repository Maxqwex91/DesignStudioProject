using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityConfiguration
{
    internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(employee => employee.Id);
            builder.Property(employee => employee.Id).ValueGeneratedOnAdd();

            builder.HasMany(employee => employee.EmployeeProjects)
                .WithOne(employeeProject => employeeProject.Employee)
                .HasForeignKey(employeeProject => employeeProject.EmployeeId);

            builder.HasMany(employee => employee.EmployeeRoles)
                .WithOne(employeeRole => employeeRole.Employee)
                .HasForeignKey(employeeRole => employeeRole.EmployeeId);

            builder.HasMany(employee => employee.EmployeeStackTechnologies)
                .WithOne(employeeStackTechnology => employeeStackTechnology.Employee)
                .HasForeignKey(employeeStackTechnology => employeeStackTechnology.EmployeeId);

            builder.HasOne(employee => employee.Office)
                .WithMany(office => office.Employees)
                .HasForeignKey(employee => employee.OfficeId);
        }
    }
}