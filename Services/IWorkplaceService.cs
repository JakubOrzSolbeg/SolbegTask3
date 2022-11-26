using SolbegTask3.Models.Workplace;

namespace SolbegTask3.Services;

public interface IWorkplaceService
{
    public Task<Workplace> PrepareWorkplaceFormModel();
    public Task AddWorkplace(Workplace model, IFormCollection collection);
}