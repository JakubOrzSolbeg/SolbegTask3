using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SolbegTask3.Models;
using SolbegTask3.Services;

namespace SolbegTask3.Controllers;

public class HomeController : Controller
{
    private bool Authorize(out string userGuid)
    {
        var guidCookie = HttpContext.Request.Cookies["employeeId"];
        if (string.IsNullOrEmpty(guidCookie))
        {
            userGuid = string.Empty;
            return false;
        }
        else
        {
            userGuid = guidCookie!;
            return true;
        }
    }
    public IActionResult Index()
    {
        if (!Authorize(out var empGuid))
        {
            return RedirectToAction("Index", "Employee");
        }
        else
        {
            return RedirectToAction("Index", "Reservation");
        }
    }
}