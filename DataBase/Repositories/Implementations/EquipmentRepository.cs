using SolbegTask3.DataBase.DbContext;
using SolbegTask3.DataBase.Repositories.Interfaces;

namespace SolbegTask3.DataBase.Repositories.Implementations;

public class EquipmentRepository : Repository, IEquipmentRepository
{
    public EquipmentRepository(MainDbContext dbContext) : base(dbContext)
    {
    }
}