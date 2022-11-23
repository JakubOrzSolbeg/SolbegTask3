using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SolbegTask3.DataBase.Entities;

public class EquipmentForWorkplace
{
    public int Id { get; set; }
    public int Count { get; set; }
    [AllowNull]
    public virtual Workplace Workplace { get; set; }
    public int WorkplaceId { get; set; }
    [AllowNull]
    public virtual Equipment Equipment { get; set; }
    
    public int EquipmentId { get; set; }
}

public class EquipmentForWorkplaceConfiguration : IEntityTypeConfiguration<EquipmentForWorkplace>
{
    public void Configure(EntityTypeBuilder<EquipmentForWorkplace> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
    }
}