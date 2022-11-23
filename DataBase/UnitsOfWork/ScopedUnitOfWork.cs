using SolbegTask3.DataBase.DbContext;
using SolbegTask3.DataBase.Repositories.Interfaces;

namespace SolbegTask3.DataBase.UnitsOfWork;

public class ScopedUnitOfWork : IMainUnitOfWork
{
    private readonly MainDbContext _dbContext;
    public IEmployeeRepository Employees { get; set; } = null!;
    public IEquipmentRepository Equipments { get; set; } = null!;
    public IWorkplaceRepository Workplaces { get; set; } = null!;
    public IReservationRepository Reservations { get; set; } = null!;

    public ScopedUnitOfWork(MainDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }
}