using SolbegTask3.DataBase.UnitsOfWork;
using SolbegTask3.Models;
using SolbegTask3.Models.Employee;

namespace SolbegTask3.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IMainUnitOfWork _mainUnitOfWork;

    public EmployeeService(IMainUnitOfWork mainUnitOfWork)
    {
        _mainUnitOfWork = mainUnitOfWork;
    }
    
    public async Task<string> RegisterEmployee(EmployeeForm employeeForm)
    {
        
        var empId = Guid.NewGuid().ToString();
        return empId;
    }
}