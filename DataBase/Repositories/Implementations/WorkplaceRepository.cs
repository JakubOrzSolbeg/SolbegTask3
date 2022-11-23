using SolbegTask3.DataBase.DbContext;
using SolbegTask3.DataBase.Repositories.Interfaces;

namespace SolbegTask3.DataBase.Repositories.Implementations;

public class WorkplaceRepository : Repository, IWorkplaceRepository
{
    public WorkplaceRepository(MainDbContext dbContext):base(dbContext)
    {
    }
}