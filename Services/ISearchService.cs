using SolbegTask3.Models.Reservation;

namespace SolbegTask3.Services;

public interface ISearchService
{
    public Task<ReservationRootModel> GetSearchResults();
    public Task<ReservationRootModel> GetSearchResults(WorkplaceSearchParams model,
        IFormCollection formCollection);
}