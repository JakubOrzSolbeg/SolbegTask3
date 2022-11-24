using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SolbegTask3.Models;
using SolbegTask3.Models.Employee;

namespace SolbegTask3.Services;

public interface IEmployeeService
{
    public Task<string> RegisterEmployee(EmployeeForm employeeForm);
}