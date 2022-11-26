using System.ComponentModel.DataAnnotations;
using SolbegTask3.DataBase.UnitsOfWork;
using SolbegTask3.Models.Reservation;

namespace SolbegTask3.Services;

public class SearchService : ISearchService
{
    private readonly IMainUnitOfWork _mainUnitOfWork;
    public SearchService(IMainUnitOfWork mainUnitOfWork)
    {
        _mainUnitOfWork = mainUnitOfWork;
    }
    public async Task<ReservationRootModel> GetSearchResults()
    {
        return new ReservationRootModel()
        {
            AwaibleWorkplaces = new List<Models.Workplace.Workplace>(),
            SearchParams = new WorkplaceSearchParams()
            {
                DateFrom = DateTime.Today.Date,
                DateTo = DateTime.Today.Date,
                Equipments = await _mainUnitOfWork.Equipments.GetAllEquipment()
            }
        };
    }

    public async Task<ReservationRootModel> GetSearchResults(WorkplaceSearchParams model, IFormCollection formCollection)
    {
        if (model.DateFrom == null || model.DateTo == null || model.DateTo < model.DateFrom)
        {
            throw new ValidationException("No date provided in search params");
        }

        model.Equipments = await _mainUnitOfWork.Equipments.GetAllEquipment();
        foreach (var modelEquipment in model.Equipments)
        {
            var exist = formCollection.ContainsKey(modelEquipment.Type.ToLower());
            modelEquipment.IsSelected = exist;
        }
        return new ReservationRootModel()
        {
            SearchParams = model,
            AwaibleWorkplaces = await _mainUnitOfWork.Workplaces.GetAllAwaible(model)
        };
    }
}