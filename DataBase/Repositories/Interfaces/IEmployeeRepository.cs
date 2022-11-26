using SolbegTask3.DataBase.Entities;

namespace SolbegTask3.DataBase.Repositories.Interfaces;

public interface IEmployeeRepository
{
    public Task AddNewEmployee(Employee employee);
    public Task<int?> GetEmployeeByGuid(string guid);
}