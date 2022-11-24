using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SolbegTask3.Models;

namespace SolbegTask3.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var employeeId = Request.Cookies["employeeId"];
        if (String.IsNullOrEmpty(employeeId))
        {
            return RedirectToAction("Index", "Employee");
        }
        
        ViewData["id"] = Request.Cookies["employeeId"];
        return View();
    }

    [HttpPost]
    public IActionResult RegisterRoom()
    {
        return View("Index");
    }
    
}