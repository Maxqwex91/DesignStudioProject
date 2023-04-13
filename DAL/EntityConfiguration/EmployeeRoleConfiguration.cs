using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityConfiguration
{
    internal sealed class EmployeeRoleConfiguration : IEntityTypeConfiguration<EmployeeRole>
    {
        public void Configure(EntityTypeBuilder<EmployeeRole> builder)
        {
            builder.ToTable("EmployeeRoles");
            builder.HasKey(employeeRole => new { employeeRole.EmployeeId, employeeRole.RoleId });

            builder.HasOne(employeeRole => employeeRole.Employee)
                .WithMany(employee => employee.EmployeeRoles)
                .HasForeignKey(employeeRole => employeeRole.EmployeeId);

            builder.HasOne(employeeRole => employeeRole.Role)
                .WithMany(role => role.EmployeeRoles)
                .HasForeignKey(employeeRole => employeeRole.RoleId);
        }
    }
}