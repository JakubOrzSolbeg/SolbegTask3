using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using SolbegTask3.DataBase.Entities;

namespace SolbegTask3.DataBase.DbContext;

public class MainDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public MainDbContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Workplace> Workplaces { get; set; } = null!;
    public DbSet<Reservation> Reservations { get; set; } = null!;
    public DbSet<Equipment> Equipments { get; set; } = null!;
    public DbSet<EquipmentForWorkplace> EquipmentForWorkplaces { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new EquipmentConfiguration());
        modelBuilder.ApplyConfiguration(new EquipmentForWorkplaceConfiguration());
        modelBuilder.ApplyConfiguration(new ReservationConfiguration());
        modelBuilder.ApplyConfiguration(new WorkplaceConfiguration());
    }
}