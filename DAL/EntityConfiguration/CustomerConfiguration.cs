using Castle.Core.Resource;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityConfiguration
{
    internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(customer => customer.Id);
            builder.Property(customer => customer.Id).ValueGeneratedOnAdd();

            builder.HasMany(customer => customer.Projects)
                .WithOne(project => project.Customer)
                .HasForeignKey(project => project.CustomerId);

            builder.HasMany(customer => customer.SocialNetworks)
                .WithOne(socialNetwork => socialNetwork.Customer)
                .HasForeignKey(socialNetwork => socialNetwork.CustomerId);
        }
    }
}