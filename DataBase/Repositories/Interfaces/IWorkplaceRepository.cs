using SolbegTask3.Models.Reservation;
using SolbegTask3.Models.Workplace;

namespace SolbegTask3.DataBase.Repositories.Interfaces;

public interface IWorkplaceRepository
{
    public Task<List<Workplace>> GetAllWorkplaces();
    public Task<List<Workplace>> GetAllAwaible(WorkplaceSearchParams searchParams);
}