using SolbegTask3.DataBase.Entities;
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
        var empGuid = Guid.NewGuid().ToString();
        await _mainUnitOfWork.Employees.AddNewEmployee(new Employee()
        {
            Guid = empGuid,
            FirstName = employeeForm.FirstName,
            LastName = employeeForm.LastName
        });
        await _mainUnitOfWork.Commit();
        return empGuid;
    }
}