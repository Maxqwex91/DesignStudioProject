using DAL.Converters;
using DAL.EntityConfiguration;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public sealed class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<EmployeeProject> EmployeesProjects { get; set; }
        public DbSet<EmployeeRole> EmployeesRoles { get; set; }
        public DbSet<EmployeeStackTechnology> EmployeesStackTechnologies { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SocialNetwork> SocialNetworks { get; set; }
        public DbSet<StackTechnology> StackTechnologies { get; set; }
        public DbSet<SystemLog> SystemLogs { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<TimeLog> TimeLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureEntities(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }

        private void ConfigureEntities(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeProjectConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeRoleConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeStackTechnologyConfiguration());
            modelBuilder.ApplyConfiguration(new OfficeConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectTaskConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new SocialNetworkConfiguration());
            modelBuilder.ApplyConfiguration(new StackTechnologyConfiguration());
            modelBuilder.ApplyConfiguration(new SystemLogConfiguration());
            modelBuilder.ApplyConfiguration(new TimeLogConfiguration());
        }
    }
}