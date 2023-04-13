using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityConfiguration
{
    internal sealed class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.ToTable("EmployeeProjects");
            builder.HasKey(employeeProject => new { employeeProject.EmployeeId, employeeProject.ProjectId });

            builder.HasMany(employeeProject => employeeProject.TimeLogs)
                .WithOne(timeLog => timeLog.EmployeeProject)
                .HasForeignKey(timeLog => new { timeLog.EmployeeId, timeLog.ProjectId });

            builder.HasOne(employeeProject => employeeProject.Employee)
                .WithMany(employee => employee.EmployeeProjects)
                .HasForeignKey(employeeProject => employeeProject.EmployeeId);
            
            builder.HasOne(employeeProject => employeeProject.Project)
                .WithMany(project=> project.EmployeeProjects)
                .HasForeignKey(employeeProject => employeeProject.ProjectId);
        }
    }
}