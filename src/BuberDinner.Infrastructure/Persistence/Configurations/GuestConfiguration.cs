using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class GuestConfiguration : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        ConfigureGuestTable(builder);
        ConfigureGuestRatingTable(builder);
        ConfigureMenuReviewIdsTable(builder);
        ConfigureBillIdsTable(builder);
        ConfigurePendingDinnerIdsTable(builder);
        ConfigurePastDinnerIdsTable(builder);
        ConfigureUpcomingDinnerIdsTable(builder);
    }

    private void ConfigureUpcomingDinnerIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(m => m.UpcomingDinnerIds, d =>
        {
            d.ToTable("UpcomingDinnerIds");

            d.WithOwner().HasForeignKey("GuestId");

            d.HasKey("Id");

            d.Property(m => m.Value)
                .HasColumnName("UpcomingDinnerId");
        });
        builder.Metadata.FindNavigation(nameof(Guest.UpcomingDinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigurePastDinnerIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(m => m.PastDinnerIds, d =>
        {
            d.ToTable("PastDinnerIds");

            d.WithOwner().HasForeignKey("GuestId");

            d.HasKey("Id");

            d.Property(m => m.Value)
                .HasColumnName("PastDinnerId");
        });
        builder.Metadata.FindNavigation(nameof(Guest.PastDinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigurePendingDinnerIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(m => m.PendingDinnerIds, d =>
        {
            d.ToTable("PendingDinnerIds");

            d.WithOwner().HasForeignKey("GuestId");

            d.HasKey("Id");

            d.Property(m => m.Value)
                .HasColumnName("PendingDinnerId");
        });
        builder.Metadata.FindNavigation(nameof(Guest.PendingDinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureBillIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(m => m.BillsIds, d =>
        {
            d.ToTable("BillsIds");

            d.WithOwner().HasForeignKey("GuestId");

            d.HasKey("Id");

            d.Property(m => m.Value)
                .HasColumnName("BillsId");
        });
        builder.Metadata.FindNavigation(nameof(Guest.BillsIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(m => m.MenuReviewIds, d =>
        {
            d.ToTable("MenuReviewIds");

            d.WithOwner().HasForeignKey("GuestId");

            d.HasKey("Id");

            d.Property(m => m.Value)
                .HasColumnName("MenuReviewId");
        });
        builder.Metadata.FindNavigation(nameof(Guest.MenuReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureGuestRatingTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(s => s.GuestRatings, sb =>
        {
            sb.ToTable("GuestRatings");

            sb.WithOwner().HasForeignKey("GuestId");

            sb.HasKey("Id", "GuestId");

            sb.Property(m => m.Id)
                .HasColumnName("GuestRatingId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => GuestRatingId.Create(value));

            sb.Property(o => o.DinnerId)
                .HasConversion(
                    id => id.Value,
                    value => DinnerId.Create(value));

            sb.Property(o => o.HostId)
                .HasConversion(
                    id => id.Value,
                    value => HostId.Create(value));

            sb.OwnsOne(p => p.Rating);
        });

        builder.Metadata.FindNavigation(nameof(Guest.GuestRatings))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureGuestTable(EntityTypeBuilder<Guest> builder)
    {
        builder.ToTable("Guests");

        builder.HasKey(g => g.Id);

        builder.Property(g => g.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => GuestId.Create(value));

        builder.Property(g => g.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(g => g.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(g => g.ProfilImage);

        builder.Property(p => p.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));

        builder.OwnsOne(g => g.AverageRating);
    }
}