using BuberDinner.Domain.DinnerAggregate;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class DinnerConfiguration : IEntityTypeConfiguration<Dinner>
{
    public void Configure(EntityTypeBuilder<Dinner> builder)
    {
        ConfigureDinnerTable(builder);
        ConfigureDinnerReservationTable(builder);
    }

    private void ConfigureDinnerReservationTable(EntityTypeBuilder<Dinner> builder)
    {
        builder.OwnsMany(s => s.DinnerReservations, sb =>
        {
            sb.ToTable("DinnerReservations");

            sb.WithOwner().HasForeignKey("DinnerId");

            sb.HasKey("Id", "DinnerId");

            sb.Property(m => m.Id)
                .HasColumnName("DinnerReservationId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => DinnerReservartionId.Create(value));

            sb.Property(o => o.GuestId)
                .HasConversion(
                    id => id.Value,
                    value => GuestId.Create(value));

        });

        builder.Metadata.FindNavigation(nameof(Dinner.DinnerReservations))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureDinnerTable(EntityTypeBuilder<Dinner> builder)
    {
        builder.ToTable("Dinners");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => DinnerId.Create(value));

        builder.Property(o => o.Name)
            .HasMaxLength(100);

        builder.Property(o => o.Description)
            .HasMaxLength(100);

        builder.Property(o => o.Status)
            .HasMaxLength(25);

        builder.Property(o => o.StartDateTime)
            .IsRequired();

        builder.Property(o => o.EndDateTime)
            .IsRequired();

        builder.OwnsOne(p => p.Location);
        builder.OwnsOne(p => p.Price);

        builder.Property(o => o.MenuId)
            .HasConversion(
                id => id.Value,
                value => MenuId.Create(value));

        builder.Property(o => o.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));

        builder.Property(o => o.Image);
    }
}