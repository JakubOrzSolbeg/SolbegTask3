using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SolbegTask3.DataBase.Entities;

public class Equipment
{
    public int Id { get; set; }
    public string Type { get; set; } = "unknown";
    [AllowNull]
    public virtual ICollection<EquipmentForWorkplace> EquipmentForWorkplaces { get; set; }
}

public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
{
    public void Configure(EntityTypeBuilder<Equipment> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.HasMany<EquipmentForWorkplace>(equipment => equipment.EquipmentForWorkplaces)
            .WithOne(eq => eq.Equipment)
            .HasForeignKey(eq => eq.EquipmentId);
    }
}

