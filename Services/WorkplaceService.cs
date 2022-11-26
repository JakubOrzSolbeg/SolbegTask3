using SolbegTask3.DataBase.UnitsOfWork;
using SolbegTask3.Models.Workplace;

namespace SolbegTask3.Services;

public class WorkplaceService : IWorkplaceService
{
    private readonly IMainUnitOfWork _mainUnitOfWork;

    public WorkplaceService(IMainUnitOfWork mainUnitOfWork)
    {
        _mainUnitOfWork = mainUnitOfWork;
    }
    public async Task<Workplace> PrepareWorkplaceFormModel()
    {
        return new Workplace()
        {
            Equipments = await _mainUnitOfWork.Equipments.GetEquipmentNames()
        };
    }

    public async Task AddWorkplace(Workplace model, IFormCollection collection)
    {
        List<string> equipmentList = collection
            .Where(pair => pair.Key.Equals(pair.Value))
            .Select(pair => pair.Key)
            .ToList();
        DataBase.Entities.Workplace workplace = new()
        {
            Floor = model.Floor,
            Room = model.Room,
            Table = model.Table
        };
        await _mainUnitOfWork.Workplaces.AddWorkplace(workplace, equipmentList);
        await _mainUnitOfWork.Commit();
    }
}