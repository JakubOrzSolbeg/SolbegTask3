using Microsoft.AspNetCore.Mvc;
using SolbegTask3.DataBase.UnitsOfWork;
using SolbegTask3.Models.Workplace;
using SolbegTask3.Services;

namespace SolbegTask3.Controllers;

public class WorkplaceController : Controller
{
    private readonly IMainUnitOfWork _mainUnitOfWork;
    private readonly IWorkplaceService _workplaceService;
    public WorkplaceController(IMainUnitOfWork mainUnitOfWork, IWorkplaceService workplaceService)
    {
        _mainUnitOfWork = mainUnitOfWork;
        _workplaceService = workplaceService;
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

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var model = await _workplaceService.PrepareWorkplaceFormModel();
        return View("WorkplaceForm", model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(Workplace model, IFormCollection collection)
    {
        await _workplaceService.AddWorkplace(model, collection);
        ModelState.Clear();
        var newmodel = await _workplaceService.PrepareWorkplaceFormModel();
        return View("WorkplaceForm", newmodel);
    }
}