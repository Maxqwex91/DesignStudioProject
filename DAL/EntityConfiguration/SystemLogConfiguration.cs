using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityConfiguration
{
    internal sealed class SystemLogConfiguration : IEntityTypeConfiguration<SystemLog>
    {
        public void Configure(EntityTypeBuilder<SystemLog> builder)
        {
            builder.ToTable("SystemLogs");
            builder.HasKey(systemLog => systemLog.Id);
            builder.Property(systemLog => systemLog.Id).ValueGeneratedOnAdd();
        }
    }
}
