using SolbegTask3.DataBase.DbContext;
using SolbegTask3.DataBase.Repositories.Interfaces;

namespace SolbegTask3.DataBase.Repositories.Implementations;

public class EmployeeRepository : Repository, IEmployeeRepository
{
    public EmployeeRepository(MainDbContext dbContext): base(dbContext)
    {
    }

    
}