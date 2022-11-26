using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SolbegTask3.DataBase.Entities;

public class Reservation
{
    public int Id { get; set; }
    public DateTime TimeFrom { get; set; }
    public DateTime TimeTo { get; set; }
    [AllowNull]
    public Workplace Workplace { get; set; }
    public int WorkplaceId { get; set; }
    [AllowNull]
    public Employee Employee { get; set; }
    public int EmployeeId { get; set; }
}

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
    }
}