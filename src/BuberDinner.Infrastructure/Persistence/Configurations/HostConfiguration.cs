using BuberDinner.Domain.HostAggregate;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class HostConfiguration : IEntityTypeConfiguration<Host>
{
    public void Configure(EntityTypeBuilder<Host> builder)
    {
        ConfigureHostTable(builder);
        ConfigureMenuIdsTable(builder);
        ConfigureDinnerIdsTable(builder);
    }

    private void ConfigureDinnerIdsTable(EntityTypeBuilder<Host> builder)
    {
        builder.OwnsMany(m => m.DinnerIds, d =>
        {
            d.ToTable("DinnerIds");

            d.WithOwner().HasForeignKey("HostId");

            d.HasKey("Id");

            d.Property(m => m.Value)
                .HasColumnName("DinnerId");
        });
        builder.Metadata.FindNavigation(nameof(Host.DinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuIdsTable(EntityTypeBuilder<Host> builder)
    {
        builder.OwnsMany(m => m.MenuIds, d =>
        {
            d.ToTable("MenuIds");

            d.WithOwner().HasForeignKey("HostId");

            d.HasKey("Id");

            d.Property(m => m.Value)
                .HasColumnName("MenuId");
        });
        builder.Metadata.FindNavigation(nameof(Host.MenuIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureHostTable(EntityTypeBuilder<Host> builder)
    {
        builder.ToTable("Hosts");

        builder.HasKey(h => h.Id);

        builder.Property(h => h.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));

        builder.Property(h => h.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(h => h.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(h => h.ProfilImage);

        builder.OwnsOne(h => h.AverageRating);

        builder.Property(h => h.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));
    }


}