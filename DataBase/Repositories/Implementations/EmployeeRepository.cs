using Microsoft.EntityFrameworkCore;
using SolbegTask3.DataBase.DbContext;
using SolbegTask3.DataBase.Entities;
using SolbegTask3.DataBase.Repositories.Interfaces;
using SolbegTask3.Models.Employee;

namespace SolbegTask3.DataBase.Repositories.Implementations;

public class EmployeeRepository : Repository, IEmployeeRepository
{
    public EmployeeRepository(MainDbContext dbContext): base(dbContext)
    {
    }


    public async Task AddNewEmployee(Employee employee)
    {
        await DbContext.Employees.AddAsync(employee);
    }

    public async Task<int?> GetEmployeeByGuid(string guid)
    {
        return (await DbContext.Employees.FirstOrDefaultAsync(e => e.Guid.Equals(guid)))?.Id;
    }
}