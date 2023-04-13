using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityConfiguration
{
    internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(role => role.Id);
            builder.Property(role => role.Id).ValueGeneratedOnAdd();

            builder.HasMany(role => role.EmployeeRoles)
                .WithOne(employeeRole => employeeRole.Role)
                .HasForeignKey(employeeRole => employeeRole.RoleId);
        }
    }
}