using Microsoft.AspNetCore.Mvc;
using SolbegTask3.Models.Reservation;

namespace SolbegTask3.Controllers;

public class ReservationController : Controller
{
    public IActionResult Index()
    {
        return View("Index", new MakeReservation());
    }

    [HttpPost]
    public IActionResult Register(MakeReservation data)
    {
        
        Console.WriteLine($"Otrzymane dane z formularza: " +
                          $"{data.DateFrom} {data.DateTo} Floor: {data.Floor}");
        // Temporary redirect
        return RedirectToAction("Index", "Reservation");
    }
}