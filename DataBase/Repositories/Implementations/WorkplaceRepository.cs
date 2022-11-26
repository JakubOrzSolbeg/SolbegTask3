using Microsoft.EntityFrameworkCore;
using SolbegTask3.DataBase.DbContext;
using SolbegTask3.DataBase.Entities;
using SolbegTask3.DataBase.Repositories.Interfaces;
using SolbegTask3.Models.Reservation;
using Workplace = SolbegTask3.Models.Workplace.Workplace;

namespace SolbegTask3.DataBase.Repositories.Implementations;

public class WorkplaceRepository : Repository, IWorkplaceRepository
{
    public WorkplaceRepository(MainDbContext dbContext):base(dbContext)
    {
    }

    public async Task<List<Workplace>> GetAllWorkplaces()
    {
        var result = await DbContext.Workplaces.Select(workplace => new Workplace()
        {
            Id = workplace.Id,
            Floor = workplace.Floor,
            Room = workplace.Room,
            Table = workplace.Table,
            Equipments = workplace.EquipmentForWorkplaces
                .Select(e => e.Equipment.Type)
                .ToList()
        }).ToListAsync();
        
        return result;
    }

    public async Task<List<Workplace>> GetAllAwaible(WorkplaceSearchParams searchParams)
    {
        var equipmentDict = await DbContext.Equipments
            .ToDictionaryAsync(equipment => equipment.Id, e=> e.Type);
        
        var ocupiedWorkplaces = (await DbContext.Reservations.Where(r => (
                (r.TimeFrom.Date <= searchParams.DateFrom!.Value.Date && r.TimeTo.Date >= searchParams.DateFrom.Value.Date) ||
                (r.TimeFrom.Date >= searchParams.DateFrom.Value.Date && r.TimeTo.Date <= searchParams.DateTo!.Value.Date) ||
                (r.TimeFrom.Date <= searchParams.DateFrom.Value.Date && r.TimeTo.Date <= searchParams.DateTo!.Value.Date && 
                 r.TimeTo.Date >= searchParams.DateFrom) ||
                (r.TimeFrom.Date >= searchParams.DateFrom.Value.Date && r.TimeFrom.Date <= searchParams.DateTo!.Value.Date && 
                 r.TimeTo.Date >= searchParams.DateTo.Value.Date)))
            .Select(r => r.WorkplaceId).ToListAsync()).ToHashSet();
        
        // Console.WriteLine($"Zajęte placówki w tym terminie {string.Join("\n", ocupiedWorkplaces)}");
        
        var requiredInventoryIds = searchParams.Equipments
            .Where(e => e.IsSelected)
            .Select(e => e.EquipmentId)
            .ToHashSet();
        
        var awaibleForDate = await DbContext.Workplaces
            .Where(w =>
                !ocupiedWorkplaces
                    .Contains(w.Id))
            .Select(workplace => new
            {
                Workplace = workplace,
                EquipmentSet = workplace.EquipmentForWorkplaces.Select(e => e.EquipmentId).ToHashSet()
            })
            .ToListAsync();
        
        var finalResult = new List<Workplace>();
        foreach (var x1 in awaibleForDate)
        {
            if (x1.EquipmentSet.IsSupersetOf(requiredInventoryIds))
            {
                finalResult.Add(new Workplace()
                {
                    Id = x1.Workplace.Id,
                    Floor = x1.Workplace.Floor,
                    Room = x1.Workplace.Room,
                    Table = x1.Workplace.Table,
                    Equipments = x1.EquipmentSet.Select(e => equipmentDict[e]).ToList()
                    
                });
            }
        }
        return finalResult;
    }

    public async Task AddWorkplace(Entities.Workplace workplace, List<string>? equipment)
    {
        DbContext.Workplaces.Add(workplace);
        await DbContext.SaveChangesAsync();
        if (equipment == null)
        {
            return;
        }
        
        foreach (var s in equipment)
        {
            var eq = await DbContext.Equipments.Where(e => e.Type.Equals(s)).Select(e => e.Id).FirstAsync();
            if (eq == 0)
            {
                continue;
            }

            await DbContext.EquipmentForWorkplaces.AddAsync(new EquipmentForWorkplace()
            {
                Count = 1,
                EquipmentId = eq,
                WorkplaceId = workplace.Id
            });
        }
    }
}