using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityConfiguration
{
    internal sealed class ProjectTaskConfiguration : IEntityTypeConfiguration<ProjectTask>
    {
        public void Configure(EntityTypeBuilder<ProjectTask> builder)
        {
            builder.ToTable("ProjectTasks");
            builder.HasKey(projectTask => projectTask.Id);
            builder.Property(projectTask => projectTask.Id).ValueGeneratedOnAdd();

            builder.HasOne(projectTask => projectTask.Project)
                .WithMany(project => project.ProjectTasks)
                .HasForeignKey(projectTask => projectTask.ProjectId);
        }
    }
}
