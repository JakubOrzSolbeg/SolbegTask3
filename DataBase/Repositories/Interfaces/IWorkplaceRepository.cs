using SolbegTask3.Models.Workplace;

namespace SolbegTask3.DataBase.Repositories.Interfaces;

public interface IWorkplaceRepository
{
    public Task<List<Workplace>> GetAllWorkplaces();
    public Task<List<Workplace>> GetAllAwaible(
        DateTime timeFrom,
        DateTime timeTo,
        int? floor = null,
        int? table = null,
        int? room = null,
        List<string>? equipments = null);
}