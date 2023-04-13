using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EntityConfiguration
{
    internal sealed class SocialNetworkConfiguration : IEntityTypeConfiguration<SocialNetwork>
    {
        public void Configure(EntityTypeBuilder<SocialNetwork> builder)
        {
            builder.ToTable("SocialNetworks");
            builder.HasKey(socialNetwork => socialNetwork.Id);
            builder.Property(socialNetwork => socialNetwork.Id).ValueGeneratedOnAdd();

            builder.HasOne(socialNetwork => socialNetwork.Customer)
                .WithMany(customer => customer.SocialNetworks)
                .HasForeignKey(socialNetwork => socialNetwork.CustomerId);
        }
    }
}