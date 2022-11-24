using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SolbegTask3.DataBase.Entities;

public class Employee
{
    public string Id { get; set; } = String.Empty;
    [AllowNull]
    public string FirstName { get; set; }
    [AllowNull]
    public string LastName { get; set; }
    [AllowNull]
    public virtual ICollection<Reservation> Reservations { get; set; }
}

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(b => b.Id);
        builder.HasMany<Reservation>(employee => employee.Reservations)
            .WithOne(reservation => reservation.Employee)
            .HasForeignKey(reservation => reservation.EmployeeId);
    }
}