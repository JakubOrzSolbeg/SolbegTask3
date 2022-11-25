using Microsoft.AspNetCore.Mvc;
using SolbegTask3.DataBase.UnitsOfWork;
using SolbegTask3.Models.Workplace;

namespace SolbegTask3.Controllers;

public class WorkplaceController : Controller
{
    private readonly IMainUnitOfWork _mainUnitOfWork;
    public WorkplaceController(IMainUnitOfWork mainUnitOfWork)
    {
        _mainUnitOfWork = mainUnitOfWork;
    }
    public async Task <IActionResult> Index()
    {
        var allWorkplace = await _mainUnitOfWork.Workplaces.GetAllWorkplaces();
        var resultModel = new WorkplaceList()
        {
            AllCount = allWorkplace.Count,
            Workplaces = allWorkplace
        };
        return View("Index", resultModel);
    }

    [HttpGet]
    public async Task<IActionResult> Equipments()
    {
        var model = new EquipmentList() { Equipments = await _mainUnitOfWork.Equipments.GetAllEquipment() };
        return View("Equipments", model: model);
    }
}