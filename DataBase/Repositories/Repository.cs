using SolbegTask3.DataBase.DbContext;

namespace SolbegTask3.DataBase.Repositories;

public abstract class Repository
{
    protected readonly MainDbContext DbContext;
    public Repository(MainDbContext dbContext)
    {
        DbContext = dbContext;
    }
}