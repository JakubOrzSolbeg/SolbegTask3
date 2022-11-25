using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using SolbegTask3.DataBase.UnitsOfWork;
using SolbegTask3.Models.Reservation;

namespace SolbegTask3.Controllers;

public class ReservationController : Controller
{
    private readonly IMainUnitOfWork _mainUnitOfWork;

    public ReservationController(IMainUnitOfWork mainUnitOfWork)
    {
        _mainUnitOfWork = mainUnitOfWork;
    }
    public async Task<IActionResult> Index()
    {
        var model = new ReservationRootModel()
        {
            AwaibleWorkplaces = await _mainUnitOfWork.Workplaces.GetAllWorkplaces(),
            SearchParams = new WorkplaceSearchParams()
            {
                DateFrom = DateTime.Today.Date,
                DateTo = DateTime.Today.Date,
                Equipments = await _mainUnitOfWork.Equipments.GetAllEquipment()
            }
        };
        Console.WriteLine($"First time model made {JsonSerializer.Serialize(model)}");
        return View("Index", model);
    }

    [HttpPost]
    public async Task<IActionResult> Register(WorkplaceSearchParams model, IFormCollection collection)
    {
        if (model.DateFrom == null || model.DateTo == null)
        {
            return BadRequest("No date provided in search params");
        }

        model.Equipments = await _mainUnitOfWork.Equipments.GetAllEquipment();
        foreach (var modelEquipment in model.Equipments)
        {
            var exist = collection.ContainsKey(modelEquipment.Type.ToLower());
            modelEquipment.IsSelected = exist;
        }
        // Console.WriteLine($"Post form model {JsonSerializer.Serialize(model)}");
        var resultModel = new ReservationRootModel()
        {
            SearchParams = model,
            AwaibleWorkplaces = await _mainUnitOfWork.Workplaces.GetAllAwaible(model)
        };
        // Console.WriteLine($"Model for view {JsonSerializer.Serialize(resultModel)}");
        return View("Index", model: resultModel);
    }
}