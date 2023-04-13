using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityConfiguration
{
    internal class TimeLogConfiguration : IEntityTypeConfiguration<TimeLog>
    {
        public void Configure(EntityTypeBuilder<TimeLog> builder)
        {
            builder.ToTable("TimeLogs");
            builder.HasKey(timeLog => timeLog.Id);
            builder.Property(timeLog => timeLog.Id).ValueGeneratedOnAdd();

            builder.HasOne(timeLog => timeLog.EmployeeProject)
                .WithMany(employeeProject => employeeProject.TimeLogs)
                .HasForeignKey(timeLog => new { timeLog.EmployeeId, timeLog.ProjectId });
        }
    }
}