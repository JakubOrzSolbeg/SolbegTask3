using Microsoft.AspNetCore.Mvc;
using SolbegTask3.Models;
using SolbegTask3.Models.Employee;
using SolbegTask3.Services;

namespace SolbegTask3.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        ModelState.Clear();
        return View("Index", new EmployeeForm());
    }
    
    [HttpPost]
    public async Task<IActionResult> RegisterEmployee(EmployeeForm employeeForm)
    {
        var empId = await _employeeService.RegisterEmployee(employeeForm);
        HttpContext.Response.Cookies.Append(key: "employeeId", value: empId);
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Logout()
    {
        HttpContext.Response.Cookies.Delete("employeeId");
        return RedirectToAction("Index", "Home");
    }
}