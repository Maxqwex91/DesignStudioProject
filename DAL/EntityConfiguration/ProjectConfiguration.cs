using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityConfiguration
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");
            builder.HasKey(project => project.Id);
            builder.Property(project => project.Id).ValueGeneratedOnAdd();

            builder.HasMany(project => project.EmployeeProjects)
                .WithOne(employeeProject => employeeProject.Project)
                .HasForeignKey(employeeProject => employeeProject.ProjectId);

            builder.HasMany(project => project.ProjectTasks)
                .WithOne(projectTask => projectTask.Project)
                .HasForeignKey(projectTask => projectTask.ProjectId);

            builder.HasOne(project => project.Customer)
                .WithMany(customer => customer.Projects)
                .HasForeignKey(project => project.CustomerId);
        }
    }
}
