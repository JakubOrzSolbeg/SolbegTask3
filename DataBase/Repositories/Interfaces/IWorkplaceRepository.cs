using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SolbegTask3.Models.Reservation;
using SolbegTask3.Models.Workplace;
using SolbegTask3.Services;

namespace SolbegTask3.DataBase.Repositories.Interfaces;

public interface IWorkplaceRepository
{
    public Task<List<Workplace>> GetAllWorkplaces();
    public Task<List<Workplace>> GetAllAwaible(WorkplaceSearchParams searchParams);
    public Task AddWorkplace(Entities.Workplace workplace, List<string>? equipment);
}