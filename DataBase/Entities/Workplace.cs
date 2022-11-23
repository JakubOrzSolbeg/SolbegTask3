using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SolbegTask3.DataBase.Entities;

public class Workplace
{
    public int Id { get; set; }
    [Range(0, Int32.MaxValue)]
    public int Floor { get; set; }
    [Range(0, Int32.MaxValue)]
    public int Room { get; set; }
    [Range(0, Int32.MaxValue)]
    public int Table { get; set; }
    [AllowNull]
    public virtual ICollection<Reservation> Reservations { get; set; }
    [AllowNull]
    public virtual ICollection<EquipmentForWorkplace> EquipmentForWorkplaces { get; set; }
}

public class WorkplaceConfiguration : IEntityTypeConfiguration<Workplace>
{
    public void Configure(EntityTypeBuilder<Workplace> builder)
    {
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.HasMany<Reservation>(workplace => workplace.Reservations)
            .WithOne(reservation => reservation.Workplace)
            .HasForeignKey(reservation => reservation.WorkplaceId);
        builder.HasMany<EquipmentForWorkplace>(workplace => workplace.EquipmentForWorkplaces)
            .WithOne(eq => eq.Workplace)
            .HasForeignKey(eq => eq.WorkplaceId);
    }
}