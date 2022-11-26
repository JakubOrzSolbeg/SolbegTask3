using Microsoft.EntityFrameworkCore;
using SolbegTask3.DataBase.DbContext;
using SolbegTask3.DataBase.Repositories.Interfaces;
using SolbegTask3.Models.Workplace;

namespace SolbegTask3.DataBase.Repositories.Implementations;

public class EquipmentRepository : Repository, IEquipmentRepository
{
    public EquipmentRepository(MainDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Equipment>> GetAllEquipment()
    {
        return await DbContext.Equipments.Select(eq => new Equipment()
            {
                EquipmentId = eq.Id,
                Type = eq.Type
            })
            .ToListAsync();
    }

    public async Task<List<string>> GetEquipmentNames()
    {
        return await DbContext.Equipments.Select(e => e.Type).ToListAsync();
    }

    public async Task<Dictionary<int, string>> GetAllEquipmentsNamesDict()
    {
        return await DbContext.Equipments
            .ToDictionaryAsync(equipment => equipment.Id, e=> e.Type);
    }
}