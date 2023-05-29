using BuberDinner.Domain.BillAggregate;
using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class BillConfigurations : IEntityTypeConfiguration<Bills>
{
    public void Configure(EntityTypeBuilder<Bills> builder)
    {
        ConfigureBillTable(builder);
    }

    private void ConfigureBillTable(EntityTypeBuilder<Bills> builder)
    {
        builder.ToTable("Bills");

        builder.HasKey(p => p.Id);

        builder.Property(o => o.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => BillsId.Create(value));

        builder.OwnsOne(p => p.Price);

        builder.Property(o => o.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));

        builder.Property(o => o.DinnerId)
            .HasConversion(
                id => id.Value,
                value => DinnerId.Create(value));

        builder.Property(o => o.GuestId)
            .HasConversion(
                id => id.Value,
                value => GuestId.Create(value));
    }
}