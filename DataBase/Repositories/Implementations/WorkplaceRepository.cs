using Microsoft.EntityFrameworkCore;
using SolbegTask3.DataBase.DbContext;
using SolbegTask3.DataBase.Repositories.Interfaces;
using SolbegTask3.Models.Workplace;

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
            Floor = workplace.Floor,
            Room = workplace.Room,
            Table = workplace.Table,
            Equipments = workplace.EquipmentForWorkplaces
                .Select(e => e.Equipment.Type)
                .ToList()
        }).ToListAsync();
        
        return result;
    }

    public async Task<List<Workplace>> GetAllAwaible(DateTime timeFrom, DateTime timeTo, int? floor = null, int? table = null, 
        int? room = null, List<string>? equipments = null)
    {
        throw new NotImplementedException();
    }
}