using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using SolbegTask3.DataBase.Entities;
using SolbegTask3.DataBase.UnitsOfWork;
using SolbegTask3.Models.Reservation;
using SolbegTask3.Services;
using Workplace = SolbegTask3.Models.Workplace.Workplace;

namespace SolbegTask3.Controllers;

public class ReservationController : Controller
{
    private readonly IMainUnitOfWork _mainUnitOfWork;
    private readonly IReservationService _reservationService;
    private readonly ISearchService _searchService;
    public ReservationController(IMainUnitOfWork mainUnitOfWork, IReservationService reservationService, 
        ISearchService searchService)
    {
        _mainUnitOfWork = mainUnitOfWork;
        _reservationService = reservationService;
        _searchService = searchService;
    }

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
    
    public async Task<IActionResult> Index()
    {
        var model2 = await _searchService.GetSearchResults();
        return View("Index", model2);
    }

    [HttpPost]
    public async Task<IActionResult> Search(WorkplaceSearchParams model, IFormCollection collection)
    {
        var model2 = await _searchService.GetSearchResults(model, collection);
        return View("Index", model: model2);
    }

    public async Task<IActionResult> Register(ReservationRequest reservationRequest)
    {
        if (!Authorize(out var empGuid))
        {
            return RedirectToAction("Index", "Employee");
        }
        await _reservationService.AddReservation(
            reservationRequest: reservationRequest,
            userGuid: empGuid
        );

        return RedirectToAction("My", "Reservation");
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        var result = await _reservationService.GetAllReservation();
        return View("AllReservationList", model: result);
    }

    [HttpGet]
    public async Task<IActionResult> My()
    {
        if (!Authorize(out var empGuid))
        {
            return RedirectToAction("Index", "Employee");
        }
        var result = await _reservationService.GetEmpReservations(empGuid);
        return View("UserReservationList", model: result);
    }

    [HttpGet]
    public async Task<IActionResult> Cancel(int reservationId)
    {
        if (!Authorize(out var empGuid))
        {
            return RedirectToAction("Index", "Employee");
        }

        await _reservationService.CancelReservation(reservationId, empGuid);
        
        return RedirectToAction("My", "Reservation");
    }
}